using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.Services;
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
        [Authorize (Roles = "Admin")]
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

        [Authorize(Roles = "Student")]
        [HttpGet("v1/users/my-profile")]
        public async Task<IActionResult> GetUser([FromServices] DataContext context)
        {
            try
            {
                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                var user = await context.Users
                    .Include(x => x.Address)
                    .Include(x => x.Role)
                    .Include(x => x.Phones)
                    .FirstOrDefaultAsync(x => x.Email == email);

                IList<string> phoneS = new List<string>();
                foreach(var phone in user.Phones)
                {
                    phoneS.Add(phone.PhoneNumber);
                }
                var userAll = new GetUserProfileViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    street = user.Address.Street,
                    Disctrict = user.Address.Disctrict,
                    State = user.Address.State,
                    Number = user.Address.Number,
                    Complement = user.Address.Complement,
                    phone = phoneS,
                    Role = user.Role.Name

                };

                return Ok(new ResultViewModel<GetUserProfileViewModel>(userAll));
            }catch (Exception ex)
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
                var user = await context.Users
                .Include(x => x.Address)
                .Include(x => x.Role)
                .Include(x => x.Phones)
                .Include(x => x.Rental)
                .ThenInclude(x => x.RentalBook)
                .FirstOrDefaultAsync(x => x.Email == email);

                if (user == null)
                {
                    return NotFound(new ResultViewModel<GetUserByEmailViewModel>("78650 - Usuário não encontrado"));
                }

                IList<string> phoneS = new List<string>();
                foreach (var phone in user.Phones)
                {
                    phoneS.Add(phone.PhoneNumber);
                }

                var userE = new GetUserByEmailViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    street = user.Address.Street,
                    Disctrict = user.Address.Disctrict,
                    State = user.Address.State,
                    Number = user.Address.Number,
                    Complement = user.Address.Complement,
                    phone = phoneS,
                    Role = user.Role.Name
                };

                if (user.Rental != null)
                {
                    userE.RentalId = user.Rental.Id;
                    userE.book = user.Rental.RentalBook.Title;
                    userE.GetDate = user.Rental.GetDate;
                    userE.ReturnDate = user.Rental.ReturnDate;
                }
                return Ok(new ResultViewModel<GetUserByEmailViewModel>(userE));
            }catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetUserProfileViewModel>("55650 - Não encontrado"));
            }     
        }


    }
}
