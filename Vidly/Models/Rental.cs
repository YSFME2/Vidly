using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {   
        public int Id { get; set; }
        [Required]
        public int MovieID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }

    }
}