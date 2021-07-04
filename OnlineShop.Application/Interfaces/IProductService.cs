using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Application.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ShowProductViewModel> GetProduct(int productNumber, string userEmail);
        Task<bool> OrderProduct(int productNumber, string email);
        Task<ShowIndexViewModel> GetIndexModel();
        Task<List<ShowSearchedProduct>> SearchProduct(string searchedPhrase);
        Task<bool> ProductLiked(int productId);
    }
}
