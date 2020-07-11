using ShoppingCart.Model;
using System.Threading.Tasks;

namespace ShoppingCart.Interface
{
    public interface ICategory
    {
        Task<ResponseModel> GetAllCategory();
        Task<ResponseModel> GetCategoryById(long CategoryId);
        Task<ResponseModel> AddOrUpdateCategory(CategoryModel CategoryModel);
        Task<ResponseModel> DeleteCategory(CategoryModel CategoryModel);
    }
}
