namespace OnlineShop.Application.ViewModels.Product
{
    public class ShowProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public uint ProductPrice { get; set; }
        public string UnitOfProduct { get; set; }
        public string ThumbnailFileName { get; set; }
        public uint OrderedCount { get; set; }
        public float? ProductRate { get; set; }
        public string CategoryPersianName { get; set; }
        public string CategoryName { get; set; }
        public bool ProductLiked { get; set; }
    }
}
