using Capi_Library_Api.Data;
using Capi_Library_Api.Services;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAllUsers([FromServices] DataContext context)
        {
            try
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

                return Ok(new ResultViewModel<List<GetAllUserViewModel>>(users));
            } catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetAllUserViewModel>("87650 - Usuarios Não encontrados"));
            }
        }
    }
}
