using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Categories;

namespace Capi_Library_Api.Services.Category
{
    public interface ICategoryService
    {
        public Task<List<SeeCategoryViewModel>> GetAllCategories(DataContext context);
    }
}
