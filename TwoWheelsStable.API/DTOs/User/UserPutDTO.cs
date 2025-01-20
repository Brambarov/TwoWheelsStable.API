using System.ComponentModel.DataAnnotations;

namespace api.DTOs.User
{
    public class UserPutDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
