﻿namespace OnlineShop.Application.ViewModels.Cart
{
    public class ShowCartProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailName { get; set; }
        public uint ProductPrice { get; set; }
        public uint Amount { get; set; }
        public string UnitOfProduct { get; set; }
    }
}
