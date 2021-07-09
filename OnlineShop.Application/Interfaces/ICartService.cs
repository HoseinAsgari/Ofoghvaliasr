using OnlineShop.Application.ViewModels.Cart;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface ICartService
    {
        Task<List<ShowCartProductViewModel>> GetCart(string email);
        Task<bool> OrderProduct(int productNumber, string email, int productCount = 1);
    }
}
