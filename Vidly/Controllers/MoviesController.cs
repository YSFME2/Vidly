using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
            //return HttpNotFound();
            //return Content("Youssef" );
            //return Redirect("https://www.google.com");
            //return File(Server.MapPath("~/El.Kanz.El.Haqiqah.wa.el.Khayal.1.2017.1080P.WEB.akwam.net.mp4"), "application/pdf","File.pdf");
        }


        //GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Inception" };
            return View(movie);
            //return new HttpNotFoundResult();
        }

        public ActionResult Par(int id)
        {
            return Content("ID = " + id);
        }

        public ActionResult Realased(int year, int month) => Content($"Year = {year} \nMounth = {month}");

        public ActionResult Find(int year,int rate,int typed,string age,string word)
        {
            return Content($"year = {year} , rate = {rate/10}/10 , type = {typed} , age = {age} , word = {word}");
        }
    }
}