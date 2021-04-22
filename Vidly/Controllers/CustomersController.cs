using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>();
        public CustomersController()
        {
            customers.Add(new Customer { ID = 1, Name = "Youssef" });
            customers.Add(new Customer { ID = 2, Name = "Mustafa" });
            customers.Add(new Customer { ID = 3, Name = "Wafaa" });
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            return View(customers.FirstOrDefault(x => x.ID == id) ?? new Customer() { ID = -1,Name = "Not Found" });
        }
    }
}