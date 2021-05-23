using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos.Rentals
{
    public class NewRentalDto
    {
        public IEnumerable<int> MovieIDs { get; set; }
        public int CustomerId { get; set; }
    }
}