using OnlineShop.Application.ViewModels.Product;
using OnlineShop.Application.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<ShowProductViewModel> GetProduct(int productNumber, string userEmail);
        Task<ShowIndexViewModel> GetIndexModel(string email);
        Task<List<ShowSearchedProduct>> SearchProduct(string searchedPhrase);
        Task<bool> ProductLiked(int productId, string userEmail);
    }
}
