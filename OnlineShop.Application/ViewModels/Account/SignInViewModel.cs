using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.ViewModels.Account
{
    public class SignInViewModel
    {
        [Display(Name = "نام و نام خانوادگی"), Required(ErrorMessage = "{0} را پر کنید"), MaxLength(100, ErrorMessage = "{0} حداکثر میتواند {1} کاراکتر داشته باشد")]
        public string Name { get; set; }

        [Display(Name = "ایمیل"), Required(ErrorMessage = "{0} را پر کنید"), MaxLength(150, ErrorMessage = "{0} حداکثر میتواند {1} کاراکتر داشته باشد"), EmailAddress(ErrorMessage = "{0}ی معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور"), Required(ErrorMessage = "{0} را پر کنید"), MaxLength(15, ErrorMessage = "{0} حداکثر میتواند {1} کاراکتر داشته باشد"), MinLength(8, ErrorMessage = "{0} حداقل باید {1} کاراکتر داشته باشد"), DataType(DataType.Password, ErrorMessage = "{0}ی معتبر وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "شماره تلفن"), Required(ErrorMessage = "{0} را پر کنید"), MaxLength(11, ErrorMessage = "{0} باید {1} کاراکتر داشته باشد"), MinLength(11, ErrorMessage = "{0} باید {1} کاراکتر داشته باشد"), DataType(DataType.PhoneNumber, ErrorMessage = "{0}ی معتبر وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "آدرس"), Required(ErrorMessage = "{0} را پر کنید"), MaxLength(100000, ErrorMessage = "{0} باید {1} کاراکتر داشته باشد"), MinLength(5, ErrorMessage = "{0} باید حداقل {1} کاراکتر داشته باشد")]
        public string UserAddress { get; set; }

        [Display(Name = "تکرار رمز عبور"), Compare(nameof(Password), ErrorMessage = "{0} با {1} همخوانی ندارد"), DataType(DataType.Password)]
        public string RePassword { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
