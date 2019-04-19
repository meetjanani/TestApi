using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Services
{
    public class CustomerRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Meet",
                Age = 21
            },
            new Customer
            {
                Id = 2,
                Name = "Heet",
                Age = 25
            }
        };
        public List<Product> Products { get; set; } = new List<Product> { };
        public IEnumerable<Customer> Get()
        {
            return Customers;
        }

        public IEnumerable<Product> Get_Product()
        {
            return Products;
        }

        public Customer Get(int id)
        {
            return Customers.Find(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            Customers.Add(customer);
        }

        public void Delete(int id)
        {
            var customer = Customers.Find(c => c.Id == id);
            Customers.Remove(customer);
        }
    }
}
