using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoGrafana.Models;

namespace TodoGrafana.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakeCustomerController : ControllerBase
    {
        // add fake get all customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var timeout = new Random().Next(1000, 5000);
            System.Threading.Thread.Sleep(timeout);

            var badrequest = new Random().Next(0, 10);
            if (badrequest == 0)
            {
                return BadRequest();
            }

            var notauthorized = new Random().Next(0, 10);
            if (notauthorized == 0)
            {
                return Unauthorized();
            }

            var customers = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = $"Customer {i}",
                    BirthDate = DateTime.Now.AddYears(-i)
                });
            }
            return customers;
        }

        // add fake get customer by id
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var timeout = new Random().Next(1000, 5000);
            System.Threading.Thread.Sleep(timeout);

            var badrequest = new Random().Next(0, 10);
            if (badrequest == 0)
            {
                return BadRequest();
            }

            var notauthorized = new Random().Next(0, 10);
            if (notauthorized == 0)
            {
                return Unauthorized();
            }

            return new Customer
            {
                Id = id,
                Name = $"Customer {id}",
                BirthDate = DateTime.Now.AddYears(-id)
            };
        }

        // add fake create customer
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            var timeout = new Random().Next(1000, 5000);
            System.Threading.Thread.Sleep(timeout);

            var badrequest = new Random().Next(0, 10);
            if (badrequest == 0)
            {
                return BadRequest();
            }

            var notauthorized = new Random().Next(0, 10);
            if (notauthorized == 0)
            {
                return Unauthorized();
            }

            return customer;
        }

        
    }
}