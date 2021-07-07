using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Application.ViewModels.Admin;

namespace OnlineShop.Application.Interfaces
{
    public interface IAdminService
    {
        Task<List<ShowUsersViewModel>> GetUsers();
        Task<bool> SetUserToAdmin(int userId);
        Task<ShowUserDetailViewModel> GetUserDetails(int userId);


        Task<List<ShowProductsAdminViewModel>> GetProductsModel();
        Task<ShowEditProductViewModel> GetEditProductModel(int productId);
        Task<bool> EditProduct(EditProductViewModel editProductViewModel);
        Task<bool> AddProduct(AddProductViewModel addProductViewModel);
        Task<bool> RemoveProduct(int productId);


        Task<ShowEditCategoryViewModel> GetEditCategoryModel(int categoryId);
        Task<List<ShowCategoriesAdminViewModel>> GetCategories();
        Task<bool> EditCategory(EditCategoryViewModel addCategoryViewModel);
        Task<bool> RemoveCategory(int categoryId);
        Task<bool> AddCategory(AddCategoryViewModel addCategoryViewModel);
    }
}