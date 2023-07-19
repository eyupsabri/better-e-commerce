using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(40)]
        public string CategoryName { get; set; }
        [Required]
        public Guid ImageGuid { get; set; }
        

        public virtual IEnumerable<Product> Products { get; set;}

    }
}