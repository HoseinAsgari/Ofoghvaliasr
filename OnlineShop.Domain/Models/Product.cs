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
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<UserProductLikes> UserProductLikes { get; set; }
        public List<UserProductViews> UserProductViews { get; set; }
        public List<UserProductSold> UserProductSolds { get; set; }
    }
}
