using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ViewModels.Shared
{
    public class ShowIndexViewModel
    {
        public List<BestTenProductsViewModel> BestTenProductsModel { get; set; }
        public List<MostSoldArrivalsViewModel> MostTenSoldProductsModel { get; set; }
    }
}
