using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.ViewModels.Account
{
    public class AccountActivateViewModel
    {
        [Required(ErrorMessage = "{0} را وارد کنید."), Display(Name = "کد فعالسازی"), StringLength(8, ErrorMessage = "{0} باید {1} کاراکتر باشد.", MinimumLength = 8)]
        public string ActivationCode { get; set; }
    }
}
