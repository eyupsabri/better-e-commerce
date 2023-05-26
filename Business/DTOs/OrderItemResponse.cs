using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class OrderItemResponse
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public ProductResponse Product { get; set; }

        public int OrderId { get; set; }

        public SessionOrder OrderItemResponseToSessionOrder() {
            return new SessionOrder() { Product = this.Product, Quantity = this.Quantity};
        }
    }
    public static class OrderItemExtention
    {
        public static OrderItemResponse OrderItemToOrderItemResponse(this OrderItem item)
        {
            return new OrderItemResponse() { OrderItemId = item.OrderItemId, Quantity = item.Quantity, 
                Product = item.Product.ToProductResponse(), OrderId = item.OrderId };
        }
    }
}
