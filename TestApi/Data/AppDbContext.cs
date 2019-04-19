using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Data
{
    public class AppDbContext : DbContext
    {
        // Add-Migration Init
        // Update-Database
        // dotnet ef migrations add Init
        // dotnet ef database update
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
