using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {

        [HttpGet("v1/roles")]
        public async Task<IActionResult> GetAllRolesAsync([FromServices] DataContext context)
        {
            List<GetAllRolesViewModel> rolesV = new List<GetAllRolesViewModel>();
            
            var roles = await context.Roles.ToListAsync();
            foreach (var role in roles)
            {
                GetAllRolesViewModel roleView = new GetAllRolesViewModel();
                roleView.Id = role.Id;
                roleView.Name = role.Name;
                rolesV.Add(roleView);
            }
            return Ok(rolesV);
        }
    }
}
