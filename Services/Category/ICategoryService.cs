using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Categories;

namespace Capi_Library_Api.Services.Category
{
    public interface ICategoryService
    {
        public Task<List<SeeCategoryViewModel>> GetAllCategories(DataContext context);
        public Task<CreateCategoryViewModel> CreateCategory(DataContext context, CreateCategoryViewModel model);
        public Task<List<CategoriesWithIdViewModel>> GetAllCategoriesWithId(DataContext context);
    }
}
