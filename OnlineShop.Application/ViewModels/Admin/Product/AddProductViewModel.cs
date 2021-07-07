using Microsoft.AspNetCore.Http;

namespace OnlineShop.Application.ViewModels.Admin.Product
{
    public class AddProductViewModel
    {
        public string ProductPersianName { get; set; }
        public uint ProductPrice { get; set; }
        public string UnitOfProduct { get; set; }
        public IFormFile ProductThumbnail { get; set; }
    }
}