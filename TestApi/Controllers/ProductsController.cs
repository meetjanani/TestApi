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
    class ProductsController : Controller
    {
        private AppDbContext _context;

        public ProductsController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        [Route("/Add")]
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Json(product);
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}