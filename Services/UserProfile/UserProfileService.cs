using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Users;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Services.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        public async Task<List<GetAllUserViewModel>> GetUsers(DataContext context)
        {
            var users = await context.Users
                  .AsNoTracking()
                  .Include(x => x.Role)
                  .Select(x => new GetAllUserViewModel
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Email = x.Email,
                      Cpf = x.Cpf,
                      Role = x.Role.Name
                  })
                  .OrderBy(x => x.Name)
                  .ToListAsync();

            if (users == null)
                return null;
            else
                return users;
        }
    }
}
