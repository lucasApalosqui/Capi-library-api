using Capi_Library_Api.Models;
using System.Security.Claims;

namespace Capi_Library_Api.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new (ClaimTypes.Name, user.Email),
                new (ClaimTypes.Role, user.Role.Name)
            };

            return result;
        }
    }
}
