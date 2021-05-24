using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos.Rentals;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;
        IMapper _mapper;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
            _mapper = App_Start.AutoMapperConfiguration.Mapper;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
            if (newRental == null)
                return BadRequest("No Data submitted");

            if (newRental.MovieIDs == null || newRental.MovieIDs.Count() == 0)
                return BadRequest("No Movie Ids have been given.");

            if (!_context.Customers.Any(x => x.ID == newRental.CustomerId))
                return BadRequest("Customer ID Not Found.");


            var movies = _context.Movies.Where(x => newRental.MovieIDs.Contains(x.Id));

            if (movies.Count() != newRental.MovieIDs.Count())
                return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberInStock == 0)
                    return BadRequest("Movie Not available.");
                var date = DateTime.Now;
                _context.Rentals.Add(new Rental() { CustomerID = newRental.CustomerId, MovieID = movie.Id, DateRented = date });
                movie.NumberInStock--;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
