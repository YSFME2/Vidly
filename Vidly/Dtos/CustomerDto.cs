using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Validations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public string MembershipType { get; set; }
    }
}