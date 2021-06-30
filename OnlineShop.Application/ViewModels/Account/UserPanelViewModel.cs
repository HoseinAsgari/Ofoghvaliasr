using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ViewModels.Account
{
    public class UserPanelViewModel
    {
        public string Email { get; set; }
        public string SignInDate { get; set; }
        public bool ActiveEmail { get; set; }
        public AccountActivateViewModel AccountActivateViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }
}
