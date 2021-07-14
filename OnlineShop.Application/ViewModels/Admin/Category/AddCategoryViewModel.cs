using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Category
{
    public class AddCategoryViewModel
    {
        [Display(Name = "نام فارسی"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string CategoryPersianName { get; set; }
        [Display(Name = "نام انگلیسی"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string CategoryEnglishName { get; set; }
        [Display(Name = "تصویر دسته بندی"), Required(ErrorMessage = "{0} را وارد کنید")]
        public IFormFile CategoryThumbnailFile { get; set; }
    }
}