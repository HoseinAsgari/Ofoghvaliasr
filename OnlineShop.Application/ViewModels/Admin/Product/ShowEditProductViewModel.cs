namespace OnlineShop.Application.ViewModels.Admin.Product
{
    public class ShowEditProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductPersianName { get; set; }
        public uint ProductPrice { get; set; }
        public string UnitOfProduct { get; set; }
        public string ProductThumbnail { get; set; }
    }
}