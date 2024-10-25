using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Motorcycle
{
    public class MotorcyclePostDTO
    {
        [Required]
        public string Make { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
    }
}
