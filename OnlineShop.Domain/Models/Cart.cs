using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public uint Price { get; set; }

        public List<CartItem> CartItems { get; set; }
        public User User { get; set; }
    }
}
