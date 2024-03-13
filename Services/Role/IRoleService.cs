using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Roles;

namespace Capi_Library_Api.Services.Role
{
    public interface IRoleService
    {
        public Task<List<GetAllRolesViewModel>> GetRoles(DataContext context);
    }
}
