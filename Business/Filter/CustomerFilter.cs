using Business.United;
using Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Filter
{
    public class CustomerFilter : BaseFilter, IFilterAndSort<Customer>
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

        public IQueryable<Customer> Sort(IQueryable<Customer> list)
        {
            switch(sortBy)
            {
                case "customerName":
                    return sortAsc ? list.OrderBy(p => p.CustomerName) : list.OrderByDescending(p => p.CustomerName);
                default:
                    return list;
            }
        }
    }
}
