using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface ICustomersRepository
    {
        Task<Customer> GetCustomerById(int CustomerId);
        Task<int> GetLatestCustomerId();
        Task<bool> AddCustomer(Customer customer);
    }

    
}
