using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; } = [];
        public List<Motorcycle> Motorcycles { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
