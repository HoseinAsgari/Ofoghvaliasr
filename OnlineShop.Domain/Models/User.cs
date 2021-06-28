using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserActivationLink { get; set; }
        public bool IsAccountActive { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool Banned { get; set; }
        public DateTime DateSignedIn { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
