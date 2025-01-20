using System.ComponentModel.DataAnnotations;

namespace TwoWheelsStable.API.DTOs.User
{
    public class UserRegisterPostDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
