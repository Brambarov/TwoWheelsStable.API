using Microsoft.AspNetCore.Identity;

namespace TwoWheelsStable.API.Models
{
    public class User : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; } = [];
        public List<Motorcycle> Motorcycles { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
