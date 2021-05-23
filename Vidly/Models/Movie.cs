using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}