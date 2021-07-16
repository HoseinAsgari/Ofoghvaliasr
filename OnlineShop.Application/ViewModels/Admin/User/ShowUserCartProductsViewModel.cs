namespace OnlineShop.Application.ViewModels.Admin.User
{
    public class ShowUserCartProductsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailName { get; set; }
        public uint Amount { get; set; }
        public string UnitOfProduct { get; set; }
        public uint Price { get; set; }
    }
}