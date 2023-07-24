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

        public OrderItem SessionToOrderItem()
        {
            OrderItem orderItem = new OrderItem() { };
            //orderItemRequest.OrderId = OrderId;
            
            orderItem.ProductId = Product.ProductId;
            orderItem.Quantity = Quantity;
            return orderItem;
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
