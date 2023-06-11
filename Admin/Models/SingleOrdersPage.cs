using Business.DTOs;
using Customer.Models;

namespace Admin.Models
{
    public class SingleOrdersPage : PagingModel
    {
        public List<CustomerResponse> Customers { get; set; }
        public string? CurrentSearchString { get; set; }
    }
}
