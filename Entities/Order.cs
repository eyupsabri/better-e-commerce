using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        //Foreign key for Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
