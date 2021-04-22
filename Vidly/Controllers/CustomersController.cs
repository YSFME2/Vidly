using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View(_context.Customers.Include(x=>x.MembershipType));
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x=>x.MembershipType).FirstOrDefault(x => x.ID == id);
            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }
    }
}