using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Users;

namespace Capi_Library_Api.Services.UserProfile
{
    public interface IUserProfileService
    {
        public Task<List<GetAllUserViewModel>> GetUsers(DataContext context);
        public Task<GetUserProfileViewModel> GetMyProfileUser(DataContext context, string email);
        public Task<GetUserByEmailViewModel> GetUserByEmail(DataContext context, string email);
        public Task<UpdateUserViewModel> UpdateUserByEmail(DataContext context, string email, UpdateUserViewModel updateUser);

    }
}
