using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Models
{
    public class UsersIPAddresses
    {
        public int Id { get; set; }
        [Required]
        public string IPAddress { get; set; }
        [Required]
        public DateTime DateLogged { get; set; }
        public User User { get; set; }
    }
}
