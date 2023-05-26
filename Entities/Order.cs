using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        [ForeignKey("Customer")]
        public int OrderId { get; set; }


        public virtual Customer Customer { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
