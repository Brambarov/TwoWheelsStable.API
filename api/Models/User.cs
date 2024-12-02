using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        public List<Motorcycle> Motorcycles { get; set; } = [];
        public bool IsDeleted { get; set; }
    }
}
