using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModel;
using AutoMapper;

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
            return View(_context.Movies.Include(x => x.Genre));
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

        public ActionResult MovieForm()
        {
            return View(new MovieFormViewModel { Genres = _context.Genres });
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.AddedDate = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpPost]
        public ActionResult SaveEdit(MovieFormViewModel editedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == editedMovie.Movie.Id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Movie, Movie>());
            new Mapper(config).Map(editedMovie.Movie, movie);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View("MovieForm",new MovieFormViewModel { Movie = movie, Genres = _context.Genres});
        }

        [Route("movies/search/{year:range(1900,2022)}/{rate}/{typed}/{age}/{word}")]
        public ActionResult Find(int year, int rate, int typed, string age, string word)
        {
            return Content($"year = {year} , rate = {rate / 10}/10 , type = {typed} , age = {age} , word = {word}");
        }
    }
}