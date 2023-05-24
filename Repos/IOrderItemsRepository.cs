using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IOrderItemsRepository
    {
        Task<bool> CreateOrderItems(List<OrderItem> items);
        Task<int> GetLatestOrderId();
        Task<bool> CreateOrder(int CustomerId);
    }
}
