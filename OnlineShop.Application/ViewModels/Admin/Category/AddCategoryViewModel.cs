using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Category
{
    public class AddCategoryViewModel
    {
        public string CategoryEnglishName { get; set; }
        public string CategoryPersianName { get; set; }
        public IFormFile CategoryThumbnailFile { get; set; }
    }
}