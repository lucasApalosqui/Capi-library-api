using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.Services;
using Capi_Library_Api.Services.UserProfile;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Capi_Library_Api.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAllUsers([FromServices] DataContext context)
        {
            try
            {
                UserProfileService userProfileService = new UserProfileService();
                List<GetAllUserViewModel> users = await userProfileService.GetUsers(context);

                if(users == null)
                    return NotFound(new ResultViewModel<GetAllUserViewModel>("87650 - Usuarios Não encontrados"));
                else
                    return Ok(new ResultViewModel<List<GetAllUserViewModel>>(users));
            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetAllUserViewModel>("87650 - Usuarios Não encontrados"));
            }
        }

        [Authorize(Roles = "Student")]
        [HttpGet("v1/users/my-profile")]
        public async Task<IActionResult> GetUser([FromServices] DataContext context)
        {
            try
            {
                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                UserProfileService profileService = new UserProfileService();

                var userAll = await profileService.GetMyProfileUser(context, email);

                if (userAll == null)
                    return NotFound(new ResultViewModel<GetUserProfileViewModel>("70050 - Não encontrado"));
                else
                    return Ok(new ResultViewModel<GetUserProfileViewModel>(userAll));


            }
            catch (Exception ex)
            { 
                return NotFound(new ResultViewModel<GetUserProfileViewModel>("78650 - Não encontrado"));
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("v1/users/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromServices] DataContext context, [FromRoute] string email)
        {
            try
            {
                UserProfileService userProfileService = new UserProfileService();

                var userE = await userProfileService.GetUserByEmail(context, email);

                if (userE == null)
                    return NotFound(new ResultViewModel<GetUserProfileViewModel>("88850 - Não encontrado"));
                else
                    return Ok(new ResultViewModel<GetUserByEmailViewModel>(userE));
            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetUserProfileViewModel>("55650 - Não encontrado"));
            }
        }

        [Authorize(Roles = "Student")]
        [HttpPut("v1/users/my-profile")]
        public async Task<IActionResult> UpdateMyProfile([FromServices] DataContext context, [FromBody] UpdateUserViewModel updateUser)
        {
            try
            {
                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                UserProfileService profileService = new UserProfileService();

                var userUpdateResponse = await profileService.UpdateUserByEmail(context, email, updateUser);

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<UpdateUserViewModel>(userUpdateResponse));
            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetUserProfileViewModel>("77750 - Não encontrado"));
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("v1/users/{email}")]
        public async Task<IActionResult> UpdateUserByEmail([FromServices] DataContext context, [FromBody] UpdateUserViewModel updateUser, [FromRoute] string email)
        {
            try
            {

                UserProfileService profileService = new UserProfileService();

                var userUpdateResponse = await profileService.UpdateUserByEmail(context, email, updateUser);

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<UpdateUserViewModel>(userUpdateResponse));
            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetUserProfileViewModel>("77750 - Não encontrado"));
            }
        }

    }
}
