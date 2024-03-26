using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Services.Category
{
    public class CategoryService : ICategoryService
    {
        public async Task<List<SeeCategoryViewModel>> GetAllCategories(DataContext context)
        {
            var allCategories = await context.Categories.AsNoTracking().ToListAsync();

            if (allCategories.Count == 0)
                return null;

            var CategoriesToSee = new List<SeeCategoryViewModel>();
            foreach(var category in allCategories)
            {
                var categoryToAdd = new SeeCategoryViewModel()
                {
                    Name = category.Name
                };

                CategoriesToSee.Add(categoryToAdd);
            }

            return CategoriesToSee;
            
        }

        public async Task<CreateCategoryViewModel> CreateCategory(DataContext context, CreateCategoryViewModel model)
        {
            Models.Category categoryToCreate = new Models.Category
            {
                Name = model.Name
            };

            await context.Categories.AddAsync(categoryToCreate);
            await context.SaveChangesAsync();

            return model;

        }

        public async Task<List<CategoriesWithIdViewModel>> GetAllCategoriesWithId(DataContext context)
        {
            var allCategories = await context.Categories.AsNoTracking().ToListAsync();

            if (allCategories.Count == 0)
                return null;

            var CategoriesToSeeWithId = new List<CategoriesWithIdViewModel>();
            foreach (var category in allCategories)
            {
                var categoryToAdd = new CategoriesWithIdViewModel()
                {
                    Name = category.Name,
                    Id = category.Id
                };

                CategoriesToSeeWithId.Add(categoryToAdd);
            }

            return CategoriesToSeeWithId;
        }
    }
}
