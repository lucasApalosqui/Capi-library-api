using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.ViewModels.Roles;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Services.Role
{
    public class RoleService : IRoleService
    {
        public async Task<List<GetAllRolesViewModel>> GetRoles(DataContext context)
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

            return rolesV;
        }
    }
}
