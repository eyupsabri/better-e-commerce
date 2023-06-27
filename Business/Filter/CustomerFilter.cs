using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public class CustomerFilter : IFilterable<Customer>
    {

        public string? CustomerName { get; set; }
        public string? ProductName { get; set; }

        public IQueryable<Customer> Filter(IQueryable<Customer> list)
        {
            if(CustomerName != null) { 
                list = list.Where(p => p.CustomerName.Contains(CustomerName));
            }
            if(ProductName != null)
            {
                list = list.Where(p => p.order.OrderItems.Any(t => t.Product.ProductName.Contains(ProductName)));
            }
            return list;
        }
    }
}
