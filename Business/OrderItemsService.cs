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
    public class OrderItemsService : IOrderItemsService
    {

        private IOrderItemsRepository _orderItemsRepo;

        public OrderItemsService(IOrderItemsRepository orderItemsRepo)
        {
            _orderItemsRepo = orderItemsRepo;
        }

        public async Task<bool> AddOrderItems(List<SessionOrder> items)
        {
            int OrderId = await _orderItemsRepo.GetLatestOrderId();

            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (SessionOrder item in items)
            {
                orderItems.Add(item.SessionOrderToOrderItemRequest(OrderId).ToOrderItem());
            }
            return await _orderItemsRepo.CreateOrderItems(orderItems);
                     
        }

        public async Task<bool> CreateOrders(int CustomerId)
        {
           return await _orderItemsRepo.CreateOrder(CustomerId);
        }
    }
}
