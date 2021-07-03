using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CartService : ICartService
    {
        public async Task<ShowCartViewModel> GetCart(string email)
        {
            return new ShowCartViewModel();
        }
    }
}
