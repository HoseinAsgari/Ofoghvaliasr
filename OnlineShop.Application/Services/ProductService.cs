using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OnlineShop.Application.ViewModels.Product;

namespace OnlineShop.Application.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ShowProductViewModel> GetProduct(int productNumber)
        {
            var product = await _productRepository.GetProduct(productNumber);
            return new ShowProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ThumbnailFileName = product.ThumbnailFileName,
                UnitOfProduct = product.UnitOfProduct
            };
        }
    }
}
