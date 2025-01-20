using System.ComponentModel.DataAnnotations;

namespace TwoWheelsStable.API.DTOs.User
{
    public class UserPutDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
