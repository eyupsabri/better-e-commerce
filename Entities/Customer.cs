using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [StringLength(40)]
        public string CustomerName { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(40)]
        public string Province { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(200)]
        public string StreetAddress { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

      
        public virtual Order order { get; set; }
        
    }
}
