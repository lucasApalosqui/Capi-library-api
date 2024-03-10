using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.Services;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("v1/accounts/register")]
        public async Task<IActionResult> Post([FromBody] RegisterAccountViewModel model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userVeri = await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (userVeri != null)
            {
                return StatusCode(400, new ResultViewModel<string>("05X77 - Email já está sendo utilizado"));
            }

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Cpf = model.Cpf             
            };

            var role = context.Roles.FirstOrDefault(x => x.Id == 1);

            user.Role = role;
            user.PasswordHash = PasswordHasher.Hash(model.Password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(404, new ResultViewModel<string>(ex.ToString()));
            }
        }

        [AllowAnonymous]
        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Post([FromBody] LoginViewModel model, [FromServices] DataContext context, [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await context.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            try
            {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, null));
            }
            catch (Exception ex) 
            {
                return StatusCode(404);
            }
        }
    }
}
