using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Category
{
    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "نام انگلیسی دسته بندی"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string CategoryEnglishName { get; set; }
        [Display(Name = "نام دسته بندی"), MinLength(2, ErrorMessage = "{0} نباید کوچکتر از {1} باشد"), MaxLength(200, ErrorMessage = "{0} نباید از {1} کاراکتر بیشتر باشد"), Required(ErrorMessage = "{0} را وارد کنید")]
        public string CategoryPersianName { get; set; }
        [Display(Name = "تصویر دسته بندی")]
        public IFormFile CategoryThumbnailFile { get; set; }
        public string CategoryThumbnailName { get; set; }
    }
}