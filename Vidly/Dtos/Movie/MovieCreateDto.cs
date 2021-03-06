using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos.Movie
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public int GenreID { get; set; }
    }
}