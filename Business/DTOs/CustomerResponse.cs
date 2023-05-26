using Business.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }
  
        public string? Gender { get; set; }

        public string Province { get; set; }
  
        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int OrderId { get; set; }
    }

    public static class CustomerExtentions
    {
        public static CustomerResponse ToCustomerResponse(this Customer customer)
        {
            return new CustomerResponse()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Province = customer.Province,
                City = customer.City,
                StreetAddress = customer.StreetAddress,
                PhoneNumber = customer.PhoneNumber,
                OrderId = customer.order.OrderId
            };
        }
    } 
}
