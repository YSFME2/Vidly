using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos.Movie
{
    public class MovieDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}