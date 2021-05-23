using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos.Rentals
{
    public class RentalDto
    {

        public int Id { get; set; }
        public int MovieID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }

        public string Customer { get; set; }
        public string Movie { get; set; }
    }
}