using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies;
        public MoviesController()
        {
            movies = new List<Movie>();
            movies.Add(new Movie { Id = 1, Name = "Inception" });
            movies.Add(new Movie { Id = 3, Name = "الفيل الازرق" });
            movies.Add(new Movie { Id = 4, Name = "Tenet" });
            movies.Add(new Movie { Id = 5, Name = "Alita the battle angel" });
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            return View(movies.FirstOrDefault(x=>x.Id == id)?? new Movie { Id = -1,Name="Not Found" });
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


        [Route("movies/search/{year:range(1900,2022)}/{rate}/{typed}/{age}/{word}")]
        public ActionResult Find(int year, int rate, int typed, string age, string word)
        {
            return Content($"year = {year} , rate = {rate / 10}/10 , type = {typed} , age = {age} , word = {word}");
        }
    }
}