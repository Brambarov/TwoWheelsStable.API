using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwoWheelsStable.API.Models
{
    [Table("RefreshTokens")]
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int MyProperty { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public bool IsRevoked { get; set; }
        public bool IsUsed { get; set; }
        public string CreatedByIp { get; set; } = string.Empty;
    }
}
