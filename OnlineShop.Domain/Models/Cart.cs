using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public uint Price { get; set; }

        public List<CartItem> CartItems { get; set; }
        public User User { get; set; }
    }
}
