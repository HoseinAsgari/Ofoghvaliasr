using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(500)]
        [Required]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
