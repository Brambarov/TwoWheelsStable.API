using System.Security.Claims;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Helpers.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            var claims = user.Claims ?? throw new ApplicationException(string.Format(ClaimExceptionError, "User"));

            var userNameClaim = claims.SingleOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"));

            return userNameClaim == null ? throw new ApplicationException(string.Format(ClaimExceptionError, "UserName")) : userNameClaim.Value;
        }
    }
}
