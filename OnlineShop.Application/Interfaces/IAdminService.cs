using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Application.ViewModels.Admin.Product;
using OnlineShop.Application.ViewModels.Admin.User;
using OnlineShop.Application.ViewModels.Admin.Category;

namespace OnlineShop.Application.Interfaces
{
    public interface IAdminService
    {
        Task<List<ShowUsersViewModel>> GetUsers();
        Task<bool> SetUserToAdmin(int userId);
        Task BanUser(int id);
        Task<ShowUserDetailsViewModel> GetUserDetails(int userId);
        Task CartDelivered(int cartId);
        Task<List<ShowUserCartProductsViewModel>> GetUserCartProducts(int cartId);


        Task<List<ShowProductsAdminViewModel>> GetProductsModel();
        Task<EditProductViewModel> GetEditProductModel(int productId);
        Task<bool> EditProduct(EditProductViewModel editProductViewModel);
        Task<bool> AddProduct(AddProductViewModel addProductViewModel);
        Task<bool> RemoveProduct(int productId);


        Task<EditCategoryViewModel> GetEditCategoryModel(int categoryId);
        Task<List<ShowCategoriesAdminViewModel>> GetCategories();
        Task<bool> EditCategory(EditCategoryViewModel addCategoryViewModel);
        Task<bool> RemoveCategory(int categoryId);
        Task<bool> AddCategory(AddCategoryViewModel addCategoryViewModel);

        Task<List<string>> GetAllCategoriesName();
        Task<List<ShowOrderesViewModel>> GetOrderes();
    }
}