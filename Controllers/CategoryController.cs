using Capi_Library_Api.Data;
using Capi_Library_Api.Services.Category;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAllCategories([FromServices] DataContext context)
        {
            try
            {
                CategoryService categoryService = new CategoryService();
                var GetAllCategoryResponse = await categoryService.GetAllCategories(context);

                if (GetAllCategoryResponse == null)
                    return NotFound(new ResultViewModel<SeeCategoryViewModel>("89OOPR - Categorias não encontradas"));

                return Ok(new ResultViewModel<List<SeeCategoryViewModel>>(GetAllCategoryResponse));

            }catch (Exception ex)
            {
                return NotFound(new ResultViewModel<SeeCategoryViewModel>("897UPR - Erro ao encontrar categorias"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("v1/categories")]
        public async Task<IActionResult> CreateCategory([FromServices] DataContext context, [FromBody] CreateCategoryViewModel category)
        {
            try
            {
                var categoryVerify = await context.Categories.FirstOrDefaultAsync(x => x.Name == category.Name);

                if (categoryVerify != null)
                    return NotFound(new ResultViewModel<CreateCategoryViewModel>("456PL - Categoria já cadastrada"));

                CategoryService categoryService = new CategoryService();
                var categoryCreateResponse = await categoryService.CreateCategory(context, category);


                return Ok(new ResultViewModel<CreateCategoryViewModel>(categoryCreateResponse));
            }
            catch (Exception e)
            {

                return NotFound(new ResultViewModel<CreateCategoryViewModel>("456JJH - Erro ao criar categoria"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("v1/categories/id-list")]
        public async Task<IActionResult> GetAllCategoriesWithId([FromServices] DataContext context)
        {
            try
            {
                CategoryService categoryService = new CategoryService();
                var GetAllCategoryWithIdResponse = await categoryService.GetAllCategoriesWithId(context);

                if (GetAllCategoryWithIdResponse == null)
                    return NotFound(new ResultViewModel<CategoriesWithIdViewModel>("8955LR - Categorias não encontradas"));

                return Ok(new ResultViewModel<List<CategoriesWithIdViewModel>>(GetAllCategoryWithIdResponse));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<CategoriesWithIdViewModel>("898UPR - Erro ao encontrar categorias"));
            }
        }
    }
}
