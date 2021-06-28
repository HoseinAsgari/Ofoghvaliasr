using System.Collections.Generic;

namespace OnlineShop.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public ulong ProductPrice { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
