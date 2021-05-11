using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            return View(new CustomerFormViewModel { MembershipTypes = _context.MembershipTypes });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("New", new CustomerFormViewModel { MembershipTypes = _context.MembershipTypes,Customer = customer });
            }
            if (customer.ID == 0)
                _context.Customers.Add(customer);
            else
                TryValidateModel(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(x => x.ID == id);
            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }
        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (cust == null)
                return HttpNotFound();
            return View("New", new CustomerFormViewModel { Customer = cust, MembershipTypes = _context.MembershipTypes });
        }
    }
}