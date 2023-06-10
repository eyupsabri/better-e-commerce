using Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICustomersService
    {
        Task<CustomerResponse> AddCustomerWithOrder(CustomerAddRequest customer, List<SessionOrder> order);
        Task<List<CustomerResponse>> GetAllCustomers();
    }
}
