using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Product
{
    public class AddProductViewModel
    {
        [Display(Name = "نام کالا"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string ProductPersianName { get; set; }
        [Display(Name = "قیمت کالا"), Range(100, 1000000000, ErrorMessage = "{0} باید بین {1} تا {2} تومان باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public uint ProductPrice { get; set; }
        [Display(Name = "واحد اندازه گیری کالا"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string UnitOfProduct { get; set; }
        [Display(Name = "دسته بندی کالا"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string CategoryName { get; set; }
        [Display(Name = "تصویر کالا"), Required(ErrorMessage = "{0} را وارد کنید")]
        public IFormFile ProductThumbnail { get; set; }
    }
}