using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category
    {
        [StringLength(40)]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public virtual IEnumerable<Product> Products { get; set;}

    }
}