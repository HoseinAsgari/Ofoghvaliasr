using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ViewModels.Shared
{
    public class MostSoldArrivalsViewModel
    {
        public string ThumbnailName { get; set; }
        public string ProductName { get; set; }
        public uint ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
    }
}
