using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Validations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Date of Birth")]
        [Mini18YearsIfaMember]
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public virtual MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}