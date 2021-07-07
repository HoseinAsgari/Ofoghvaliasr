using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Category
{
    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryEnglishName { get; set; }
        public uint CategoryPersianName { get; set; }
        public IFormFile CategoryThumbnailFile { get; set; }
    }
}