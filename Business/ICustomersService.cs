﻿using Business.DTOs;
using Business.PageList;
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
        Task<List<CustomerResponse>> GetPaginatedCustomers(int position);
        Task<int> CustomersCount();
        //Task<List<CustomerResponse>> GetCustomersByNameSearchPaginated(string search, int position);
        IPagedList<CustomerResponse> GetCustomers(string? customerName, string? productName, int pageIndex);
        Task<int> GetCustomersCountByNameSearch(string search);
    }
}
