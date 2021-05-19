using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MoviesDisplay
    {
        public IEnumerable<Movie> Movies { get; set; }
        public bool CanManageMovies { get; set; }
    }
}