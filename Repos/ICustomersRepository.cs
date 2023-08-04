using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface ICustomersRepository
    {
        Task<Customer> GetCustomerById(int CustomerId);
        Task<Customer>? GetLatestCustomer();
       
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetPaginatedCustomers(int position);
        Task<int> CustomersCount();
        Task<int> GetCustomersCountByNameSearch(string search);
        //Task<List<Customer>> GetCustomersByNameSearchPaginated(string search, int position);
        IQueryable<Customer> GetCustomers();

        Task<int> AddCustomer(Customer customer);// old one with gradual adding
        

    }
    
}
