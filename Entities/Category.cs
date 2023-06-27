using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category
    {
        public bool IsDeleted { get; set; }
        [StringLength(40)]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public virtual IEnumerable<Product> Products { get; set;}

    }
}