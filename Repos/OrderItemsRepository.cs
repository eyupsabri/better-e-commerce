using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly AppDbContext _orderItemRepo;

        public OrderItemsRepository(AppDbContext orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        public async Task<bool> CreateOrderItems(List<OrderItem> items)
        {
            foreach (OrderItem item in items)
            {
                _orderItemRepo.OrderItems.Add(item);
            }

            int success =  await _orderItemRepo.SaveChangesAsync();
            return success > items.Count;
        }

        public async Task<int> GetLatestOrderId()
        {
             List<Order> orders = await _orderItemRepo.Orders.ToListAsync();
             if(orders.Count == 0)
            {
                return -1;
            }else
            {
                return orders.Max(x => x.OrderId); 
            }
        }

        public async Task<bool> CreateOrder(int CustomerId)
        {
            _orderItemRepo.Orders.Add(new Order() { CustomerId = CustomerId });
            int success = await _orderItemRepo.SaveChangesAsync();
            return success > 0;
        }
    }
}
