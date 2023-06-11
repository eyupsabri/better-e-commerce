using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<List<Customer>> GetPaginatedCustomers(int position)
        {
            return await _db.Customers                              
                .Skip(position * 12)
                .Include("order")
                .Take(12)
                .ToListAsync();
        }

        public async Task<int> CustomersCount()
        {
            return await _db.Customers.CountAsync();
        }

        public async Task<int> GetCustomersCountByNameSearch(string search)
        {
            return await _db.Customers
             .Where(temp => temp.CustomerName.Contains(search))
             .CountAsync();
        }

        public async Task<List<Customer>> GetCustomersByNameSearchPaginated(string search,int position)
        {
            return await _db.Customers
                .Where(temp =>temp.CustomerName.Contains(search))
                .Skip(position * 12)
                .Include("order")
                .Take(12)
                .ToListAsync();
        }
    }
}
