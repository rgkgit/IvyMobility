using ShoppingCart.Model;
using System.Threading.Tasks;

namespace ShoppingCart.Interface
{
    public interface ISubCategory
    {
        Task<ResponseModel> GetAllSubCategory(long CategoryId);
        Task<ResponseModel> GetSubCategoryById(long subCategoryId);
        Task<ResponseModel> AddOrUpdateSubCategory(SubCategoryModel subCategoryModel);
        Task<ResponseModel> DeleteSubCategory(SubCategoryModel subCategoryModel);
    }
}
