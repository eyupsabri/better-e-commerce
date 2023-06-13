using Business.Enums;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class CustomerAddRequest
    {

        [StringLength(40)]
        [Required(ErrorMessage = "Name can't be blank")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email")]
        [StringLength(40)]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }


        public GenderOptions? Gender { get; set; }

        [Required(ErrorMessage = "Province can't be blank")]
        [StringLength(40)]
        public string Province { get; set; }

        [Required(ErrorMessage = "City can't be blank")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "Address can't be blank")]
        [StringLength(200)]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Phone number can't be blank")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        //public IEnumerable<Order>? Orders { get; set; }

        public Customer ToCustomer()
        {//Burada enum null mu diye bak null olarak gir yoksa empty string atıyor
            return new Customer() { CustomerName = CustomerName, Email = Email, DateOfBirth = DateOfBirth, 
                Gender = Gender.ToString(), Province = Province, City = City, 
                StreetAddress = StreetAddress, PhoneNumber = PhoneNumber };

        }
    }
}
