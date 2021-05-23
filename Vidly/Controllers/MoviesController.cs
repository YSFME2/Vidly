using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModel;
using AutoMapper;
using static Vidly.App_Code.RoleName;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(new MoviesDisplay { Movies = _context.Movies.Include(x => x.Genre), CanManageMovies = User.IsInRole(App_Code.RoleName.CanManageMovies) });
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            if (movie != null)
                return View(movie);
            else
                return HttpNotFound();
        }

        //GET: Movies/Random
        public ActionResult Random(int id)
        {
            var movie = new Movie() { Name = "Inception" };
            var customers = new List<Customer>();
            for (int i = 0; i < id; i++)
            {
                customers.Add(new Customer { Name = "customer " + i });
            }
            var rand = new RandomViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(rand);
        }

        [Authorize(Roles = CanManageMovies)]
        public ActionResult MovieForm()
        {
            return View(new MovieFormViewModel { Genres = _context.Genres, Movie = new Movie() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = CanManageMovies)]
        public ActionResult Create(Movie movie)
        {
            movie.AddedDate = DateTime.Now;
            if (!ModelState.IsValid)
                return View("MovieForm", new MovieFormViewModel { Genres = _context.Genres, Movie = movie });
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = CanManageMovies)]
        public ActionResult SaveEdit(MovieFormViewModel editedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == editedMovie.Movie.Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Movie, Movie>());
            new Mapper(config).Map(editedMovie.Movie, movie);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        [Authorize(Roles = CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View("MovieForm", new MovieFormViewModel { Movie = movie, Genres = _context.Genres });
        }

        [Route("movies/search/{year:range(1900,2022)}/{rate}/{typed}/{age}/{word}")]
        public ActionResult Find(int year, int rate, int typed, string age, string word)
        {
            return Content($"year = {year} , rate = {rate / 10}/10 , type = {typed} , age = {age} , word = {word}");
        }


        [HttpDelete]
        [Authorize(Roles = CanManageMovies)]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x=>x.Id == id);
            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Content($"{movie.Name} deleted successfully");
        }
    }
}