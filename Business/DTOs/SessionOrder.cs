using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class SessionOrder
    {
        public ProductResponse Product { get; set; }
        public int Quantity { get; set; }

        public OrderItemRequest SessionOrderToOrderItemRequest(int OrderId)
        {
            OrderItemRequest orderItemRequest = new OrderItemRequest() { };
            orderItemRequest.OrderId = OrderId;
            orderItemRequest.ProductId = Product.ProductId;
            orderItemRequest.Quantity = Quantity;
            return orderItemRequest;
        }

        public override bool Equals(object? obj)
        {
            // If the passed object is null, return False
            if (obj == null)
            {
                return false;
            }
            // If the passed object is not Customer Type, return False
            if (!(obj is SessionOrder))
            {
                return false;
            }
            return (this.Product.ProductId== ((SessionOrder)obj).Product.ProductId);
               
        }
    }
}
