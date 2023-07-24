using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//BU SINIFI PATLATTIM
namespace Business.DTOs
{
    public class OrderItemRequest
    {

        public int Quantity { get; set; }

        public int ProductId { get; set; }

       // public int OrderId { get; set; }

        public OrderItem ToOrderItem()
        {
            return new OrderItem() { Quantity = Quantity, ProductId = ProductId };
        }
    }

}
