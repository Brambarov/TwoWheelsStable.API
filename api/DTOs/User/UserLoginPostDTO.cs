using System.ComponentModel.DataAnnotations;

namespace api.DTOs.User
{
    public class UserLoginPostDTO
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
