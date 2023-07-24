using Entities;
using System.ComponentModel.DataAnnotations;
using static Entities.Enums.DbEnums;

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

        public List<SessionOrder> Session { get; set; }

        public Customer ToCustomer()
        {//Burada enum null mu diye bak null olarak gir yoksa empty string atıyor


            List<OrderItem> items = new List<OrderItem>();
            foreach (var item in Session)
            {
                items.Add(item.SessionToOrderItem());
            }


            var custo = new Customer() { CustomerName = CustomerName, Email = Email, DateOfBirth = DateOfBirth, 
                Gender = Gender, Province = Province, City = City, 
                StreetAddress = StreetAddress, PhoneNumber = PhoneNumber,
                order = new Order()
                {
                    OrderItems = new List<OrderItem>(items)
                }
            };
            return custo;
        }
        
    }
}
