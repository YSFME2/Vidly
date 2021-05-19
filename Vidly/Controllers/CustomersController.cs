using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;
using static Vidly.App_Code.RoleName;
using Vidly.Dtos;

namespace Vidly.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        AutoMapper.IMapper _mapper;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _mapper = App_Start.AutoMapperConfiguration.Mapper;
        }

        public ActionResult New()
        {
            return View(new CustomerFormViewModel { MembershipTypes = _context.MembershipTypes });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = CanManageCustomers)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("New", new CustomerFormViewModel { MembershipTypes = _context.MembershipTypes, Customer = customer });
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = CanManageCustomers)]
        public ActionResult Delete(int id)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (cust == null)
                return HttpNotFound();

            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View(new CustomersDisplay() { Customers = _context.Customers.ToList(), CanCustomerManage = User.IsInRole(CanManageCustomers) });
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(x => x.ID == id);
            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }


        [Authorize(Roles = CanManageCustomers)]
        public ActionResult Edit(int id)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (cust == null)
                return HttpNotFound();
            return View("New", new CustomerFormViewModel { Customer = cust, MembershipTypes = _context.MembershipTypes });
        }
    }
}