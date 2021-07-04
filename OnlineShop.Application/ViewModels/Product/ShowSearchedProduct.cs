using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ViewModels.Product
{
    public class ShowSearchedProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ThumbnailName { get; set; }
        public uint ProductPrice { get; set; }
    }
}
