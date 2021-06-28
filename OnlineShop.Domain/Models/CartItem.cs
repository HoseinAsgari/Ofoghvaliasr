using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public uint Count { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
