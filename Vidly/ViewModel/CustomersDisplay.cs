using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomersDisplay
    {
        public IEnumerable<Customer> Customers { get; set; }
        public bool CanCustomerManage { get; set; }
    }
}