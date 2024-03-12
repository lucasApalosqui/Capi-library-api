using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("v1/roles")]
        public async Task<IActionResult> GetAllRolesAsync([FromServices] DataContext context)
        {
            List<GetAllRolesViewModel> rolesV = new List<GetAllRolesViewModel>();
            try
            {
                var roles = await context.Roles.ToListAsync();
                foreach (var role in roles)
                {
                    GetAllRolesViewModel roleView = new GetAllRolesViewModel();
                    roleView.Id = role.Id;
                    roleView.Name = role.Name;
                    rolesV.Add(roleView);
                }
                return Ok(new ResultViewModel<List<GetAllRolesViewModel>>(rolesV));

            } catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetAllRolesViewModel>("08T56 - Role não encontrada"));
            }
            
        }
    }
}
