using Business.DTOs;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomersService : ICustomersService
    {

        private ICustomersRepository _customersRepo;
        private IOrderItemsService _orderItemsService;

        public CustomersService(ICustomersRepository repository, IOrderItemsService orderItemsService)
        {
            _customersRepo = repository;
            _orderItemsService = orderItemsService;
        }


        public async Task<bool> AddCustomerWithOrder(CustomerAddRequest customer, List<SessionOrder> order)
        {
            await _customersRepo.AddCustomer(customer.ToCustomer());
            int CustomerId = await _customersRepo.GetLatestCustomerId();
            await _orderItemsService.CreateOrders(CustomerId);
            await _orderItemsService.AddOrderItems(order);

            return true;
        }


    }
}
