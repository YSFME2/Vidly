using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Autofac;
using AutoMapper;
using Vidly.Dtos;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _mapper = App_Start.AutoMapperConfiguration.Mapper;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        //get all cutomers
        public IEnumerable<CustomerDto> GetCustomers() => _mapper.Map<List<Customer>, List<CustomerDto>>(_context.Customers.ToList());

        //get customer
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }


        //create customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerCreateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = _mapper.Map<CustomerCreateDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(Request.RequestUri + "/" + customer.ID, customerDto);
        }


        //edit customer
        [HttpPut]
        public IHttpActionResult EditCustomer(int id, CustomerCreateDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cust = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (cust == null)
                return NotFound();
            _mapper.Map(customerDto, cust);
            _context.SaveChanges();
            return Ok(_mapper.Map<Customer,CustomerDto>(cust));
        }


        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var cust = _context.Customers.FirstOrDefault(x => x.ID == id);
            if (cust == null)
                return BadRequest();

            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return Ok();
        }
    }
}
