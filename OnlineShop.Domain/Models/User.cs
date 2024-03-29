﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(350)]
        public string UserName { get; set; }
        [MaxLength(350)]
        [Required]
        public string UserEmail { get; set; }
        [MaxLength(10000)]
        [Required]
        public string UserPassword { get; set; }
        [MaxLength(10000)]
        public string UserActivationLink { get; set; }
        public bool IsAccountActive { get; set; }
        [MaxLength(11)]
        [Required]
        public string UserPhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool Banned { get; set; }
        public DateTime DateSignedIn { get; set; }        
        [MaxLength(100000)]
        [Required]
        public string UserAddress { get; set; }

        public List<Cart> Carts { get; set; }
        public List<UserProductLikes> LikedProducts { get; set; }
        public List<UserProductViews> UserProductViews { get; set; }
        public List<UserProductSold> UserProductSolds { get; set; }
        public List<UsersIPAddresses> UsersIPAddresses { get; set; }
    }
}
