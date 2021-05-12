using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos.Movie;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            _mapper = App_Start.AutoMapperConfiguration.Mapper;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //get all movies
        public IHttpActionResult GetMovies() => Ok(_mapper.Map<List<Movie>,List<MovieDto>>(_context.Movies.ToList()));


        //get movie by id 
        public IHttpActionResult GetMovie(int id)
        {
            var mov = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (mov == null)
                return NotFound();

            return Ok(_mapper.Map<Movie,MovieDto>(mov));
        }



        //get the result of searching
        [HttpGet]
        [Route("api/Movies/Sreach/{word}")]
        public IHttpActionResult Search(string word)
        {
            int id = 0;
            int.TryParse(word, out id);
            return Ok(_mapper.Map<List<Movie>,List<MovieDto>>(_context.Movies.Where(x => x.Id == id || x.Name.Contains(word)
            || x.Genre.Name.Contains(word) || x.NumberInStock == id || x.GenreID == id).ToList()));
        }


        //post to create movie
        [HttpPost]
        public IHttpActionResult Create(MovieCreateDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mov = _mapper.Map<MovieCreateDto,Movie>(movie);
            mov.AddedDate = DateTime.Now;

            _context.Movies.Add(mov);
            _context.SaveChanges();
            return Created(Request.RequestUri + "/" + mov.Id, _mapper.Map<MovieDto>(mov));
        }



        //put to update movie
        [HttpPut]
        public IHttpActionResult Update(int id, MovieCreateDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var mov = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (mov == null)
                return NotFound();
            _mapper.Map(movie, mov);
            _context.SaveChanges();
            return Ok(_mapper.Map<Movie,MovieDto>(mov));
        }


        //delete movie
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var mov = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (mov == null)
                return NotFound();
            _context.Movies.Remove(mov);
            _context.SaveChanges();
            return Ok();
        }
    }
}
