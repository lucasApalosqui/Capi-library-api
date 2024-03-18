using Capi_Library_Api.Data;
using Capi_Library_Api.Services.Category;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
