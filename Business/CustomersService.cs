using Business.DTOs;
using Entities;
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


        public async Task<CustomerResponse> AddCustomerWithOrder(CustomerAddRequest customerAddReq, List<SessionOrder> order)
        {
            await _customersRepo.AddCustomerWithoutOrderId(customerAddReq.ToCustomer());//Order no olmadan ekliyorum.
            Customer? customer = await _customersRepo.GetLatestCustomer();//Eklenen Customer ı alıyorum
            if (customer != null)
            {
                await _orderItemsService.CreateOrders(customer); //Customer ile order yaratıyorum
                await _orderItemsService.AddOrderItems(order);//order item ekleme
            }
            CustomerResponse response = customer.ToCustomerResponse();
            response.Items = order;
            return response;
        }

        public async Task<List<CustomerResponse>> GetAllCustomers()
        {
            List<Customer> customers = await _customersRepo.GetAllCustomers();
            List<CustomerResponse> customerRespones = new List<CustomerResponse>();
            if(customers.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    customerRespones.Add(customer.ToCustomerResponse());
                }
            }
            return customerRespones;

        }
    }
}
