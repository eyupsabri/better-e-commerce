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
        Task<Customer>? GetLatestCustomer();
        Task<bool> AddCustomerWithoutOrderId(Customer customer);
        //Task<bool> AddOrderIdToCustomer(int OrderId, Customer customer);
    }

    
}
