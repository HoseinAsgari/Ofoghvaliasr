using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
