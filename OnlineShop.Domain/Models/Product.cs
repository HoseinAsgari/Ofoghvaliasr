using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(500)]
        [Required]
        public string ProductName { get; set; }
        public uint ProductPrice { get; set; }
        [MaxLength(500)]
        [Required]
        public string UnitOfProduct { get; set; }

        public List<CartItem> CartItems { get; set; }
        public Category Category { get; set; }
    }
}
