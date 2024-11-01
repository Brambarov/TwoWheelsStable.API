using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Motorcycle
{
    public class MotorcyclePostDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Make { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Range(1901, int.MaxValue, ErrorMessage = "Year must be greater than 1900!")]
        public int Year { get; set; }
    }
}
