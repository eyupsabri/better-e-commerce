using Business.DTOs;
using Business.PageList;
using Entities;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Filter;
using Business.United;

namespace Business
{
    public class CustomersService : ICustomersService
    {

        private ICustomersRepository _customersRepo;
        //private IOrderItemsService _orderItemsService;

        public CustomersService(ICustomersRepository repository)
        {
            _customersRepo = repository;
            //_orderItemsService = orderItemsService;
        }


        public async Task<CustomerResponse> AddCustomerWithOrder(CustomerAddRequest customerAddReq, List<SessionOrder> order)
        {
            customerAddReq.Session = new List<SessionOrder>();
            customerAddReq.Session = order;

            var custoId = await _customersRepo.AddCustomer(customerAddReq.ToCustomer());
            var custo = await _customersRepo.GetCustomerById(custoId);
            var response = custo.ToCustomerResponse();
           

            //await _customersRepo.AddCustomerWithoutOrderId(customerAddReq.ToCustomer());//Order no olmadan ekliyorum.
            //Customer? customer = await _customersRepo.GetLatestCustomer();//Eklenen Customer ı alıyorum
            //if (customer != null)
            //{
            //    await _orderItemsService.CreateOrders(customer); //Customer ile order yaratıyorum
            //    await _orderItemsService.AddOrderItems(order);//order item ekleme
            //}
            //CustomerResponse response = customer.ToCustomerResponse();
            //response.Items = order;
            return response;
        }



        //public async Task<List<CustomerResponse>> GetAllCustomers()
        //{
        //    List<Customer> customers = await _customersRepo.GetAllCustomers();
        //    List<CustomerResponse> customerRespones = new List<CustomerResponse>();
        //    if (customers.Count > 0)
        //    {
        //        foreach (Customer customer in customers)
        //        {
        //            customerRespones.Add(customer.ToCustomerResponse());
        //        }
        //    }
        //    return customerRespones;

        //}

        //public async Task<List<CustomerResponse>> GetPaginatedCustomers(int position)
        //{
        //    List<Customer> customers = await _customersRepo.GetPaginatedCustomers(position);
        //    return customers.Select(x => x.ToCustomerResponse()).ToList();
        //}

        //public async Task<int> GetCustomersCountByNameSearch(string search)
        //{
        //    return await _customersRepo.GetCustomersCountByNameSearch(search);
        //}

        //public async Task<int> CustomersCount()
        //{
        //    return await _customersRepo.CustomersCount();
        //}

        public  IPagedList<CustomerResponse> GetFilteredCustomers(IFilterAndSort<Customer> filter, int pageIndex)
        {
            var list = _customersRepo.GetCustomers();

            var filtered = list.FilterAndSort(filter);

            //var filtered = filter.Filter(list);

            IPagedList<CustomerResponse> response = filtered.Select(_ => _.ToCustomerResponse()).ToPagedList(pageIndex, 12);

            return response;
        }

        //public async Task<List<CustomerResponse>> GetCustomersByNameSearchPaginated(string search, int position)
        //{
        //    List<Customer> customers = await _customersRepo.GetCustomersByNameSearchPaginated(search, position);
        //    List<CustomerResponse> customerResponses = customers.Select(customer => customer.ToCustomerResponse()).ToList();
        //    return customerResponses;
        //}

    }
}


