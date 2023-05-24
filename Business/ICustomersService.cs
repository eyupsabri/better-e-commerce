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
        Task<bool> AddCustomerWithOrder(CustomerAddRequest customer, List<SessionOrder> order);
    }
}
