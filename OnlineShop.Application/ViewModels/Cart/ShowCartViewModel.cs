namespace OnlineShop.Application.ViewModels.Cart
{
    public class ShowCartViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailName { get; set; }
        public uint ProductPrice { get; set; }
        public string UnitOfProduct { get; set; }
        public string Amount { get; set; }
    }
}
