using System.Security.Claims;

namespace api.Helpers.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
            var claims = user.Claims ?? throw new ApplicationException("User claims exception!");

            var userNameClaim = claims.SingleOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"));

            return userNameClaim == null ? throw new ApplicationException("Username claim exception!") : userNameClaim.Value;
        }
    }
}
