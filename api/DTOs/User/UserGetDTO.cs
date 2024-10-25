using System.ComponentModel.DataAnnotations;

namespace api.DTOs.User
{
    public class UserGetDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
