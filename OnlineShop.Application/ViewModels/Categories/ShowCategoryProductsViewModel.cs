﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ViewModels.Categories
{
    public class ShowCategoryProductsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public uint ProductPrice { get; set; }
        public string ProductThumbnail { get; set; }
    }
}
