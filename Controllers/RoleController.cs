using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.Services.Role;
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
            try
            {
                RoleService roleService = new RoleService();

                var rolesV = await roleService.GetRoles(context);

                if(rolesV == null)
                    return NotFound(new ResultViewModel<GetAllRolesViewModel>("08J56 - Role não encontrada"));         

                return Ok(new ResultViewModel<List<GetAllRolesViewModel>>(rolesV));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetAllRolesViewModel>("08T56 - Role não encontrada"));
            }

        }
    }
}
