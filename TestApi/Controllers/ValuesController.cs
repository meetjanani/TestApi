using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Data;
using TestApi.Models;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private AppDbContext _context;

        public ValuesController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Customers.Where(c => c.Id > 0));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _context.Customers.FindAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Json(customer);
            }
            // var pro = _context.Products.Where(c => c.Id == 1).Include(p => p.Customer);
            // Task Paraller Library (TPL) with async / await
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
            return NoContent();
        }

        // PUT api/values/5
        [HttpPatch("{id}")]
        public void Patch(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
