using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _db;

        public CustomersRepository(AppDbContext appDbContext) {
        
            _db = appDbContext;
        }

       
        public async Task<Customer> GetCustomerById(int CustomerId)
        {
            return await _db.Customers.FirstOrDefaultAsync(temp => temp.CustomerId == CustomerId);
        }

        public async Task<bool> AddCustomerWithoutOrderId(Customer customer)
        {
            _db.Customers.Add(customer);
            int success = await _db.SaveChangesAsync();
            return success > 0;
        }

        public async Task<Customer>? GetLatestCustomer()
        {
            List<Customer> customers = await _db.Customers.ToListAsync();

            if(customers.Count == 0)
            {
                return null;
            }
            return customers[customers.Count - 1];

        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = await _db.Customers.Include("order").ToListAsync();
            return customers;
        }
    }
}
