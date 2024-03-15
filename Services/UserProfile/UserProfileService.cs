using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        public async Task<GetUserProfileViewModel> GetMyProfileUser(DataContext context, string email)
        {

            var user = await context.Users
                    .Include(x => x.Address)
                    .Include(x => x.Role)
                    .Include(x => x.Phones)
                    .FirstOrDefaultAsync(x => x.Email == email);

            IList<string> phoneS = new List<string>();
            foreach (var phone in user.Phones)
            {
                phoneS.Add(phone.PhoneNumber);
            }

            if (user.Address != null && user.Phones != null)
            {
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
                return userAll;
            }

            if (user.Address == null)
            {
                var userAll = new GetUserProfileViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    phone = phoneS,
                    Role = user.Role.Name

                };
                return userAll;
            }

            if (user.Phones == null)
            {
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
                    Role = user.Role.Name

                };
                return userAll;
            }
            else
            {
                var userAll = new GetUserProfileViewModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Cpf = user.Cpf,
                    Role = user.Role.Name

                };
                return userAll;
            }
        }

        public async Task<GetUserByEmailViewModel> GetUserByEmail(DataContext context, string email)
        {
            var user = await context.Users
                .Include(x => x.Address)
                .Include(x => x.Role)
                .Include(x => x.Phones)
                .Include(x => x.Rental)
                .ThenInclude(x => x.RentalBook)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

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

            return userE;
        }

        public async Task<UpdateUserViewModel> UpdateUserByEmail(DataContext context, string email, UpdateUserViewModel updateUser)
        {
            var user = await context.Users
                    .Include(x => x.Address)
                    .Include(x => x.Phones)
                    .FirstOrDefaultAsync(x => x.Email == email);

            Address adress = new Address
            {
                Street = updateUser.street,
                State = updateUser.State,
                Disctrict = updateUser.Disctrict,
                Number = updateUser.Number,
                Complement = updateUser.Complement
            };

            if (user.Address == null)
                user.Address = adress;

            else
            {
                var addressActual = await context.Addresses.FirstOrDefaultAsync(x => x.UserId == user.Id);
                addressActual.Street = adress.Street;
                addressActual.State = adress.State;
                addressActual.Number = adress.Number;
                addressActual.Disctrict = adress.Disctrict;
                addressActual.Complement = adress.Complement;

                context.Addresses.Update(addressActual);
            }

            IList<Phone> phones = new List<Phone>();

            foreach (var phoneNumber in updateUser.PhoneNumber)
            {
                Phone phoneClass = new Phone
                {
                    PhoneNumber = phoneNumber
                };
                phones.Add(phoneClass);
            }

            user.Phones = phones;

            user.Name = updateUser.Name;

            var emailInUseCheck = context.Users.FirstOrDefault(x => x.Email == updateUser.Email);

            if (emailInUseCheck == null)
                return null;
            
            user.Email = updateUser.Email;

            context.Users.Update(user);

            UpdateUserViewModel userUpdateResponse = new UpdateUserViewModel
            {
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = updateUser.PhoneNumber,
                street = adress.Street,
                Disctrict = adress.Disctrict,
                State = adress.State,
                Number = adress.Number,
                Complement = adress.Complement

            };

            return userUpdateResponse;
        }


    }
}
