using OnlineShop.Application.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ShowProductViewModel> GetProduct(int productNumber, string userEmail);
        Task<bool> OrderProduct(int productNumber, string email);
    }
}
