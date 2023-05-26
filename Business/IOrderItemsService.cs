using Business.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IOrderItemsService
    {
        Task<bool> AddOrderItems(List<SessionOrder> items);
        Task<bool> CreateOrders(Customer customer);
        Task<int> GetLatestOrderId();
        Task<List<SessionOrder>> GetAllOrderItemsByOrderId(int orderId);
    }
}
