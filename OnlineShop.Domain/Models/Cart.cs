using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public uint Price { get; set; }
        public bool IsOrdered { get; set; }
        public DateTime? DateOrdered { get; set; }
        public bool Delivered { get; set; }

        public List<CartItem> CartItems { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
