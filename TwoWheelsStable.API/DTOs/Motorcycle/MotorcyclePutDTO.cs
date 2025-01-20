using System.ComponentModel.DataAnnotations;

namespace TwoWheelsStable.API.DTOs.Motorcycle
{
    public class MotorcyclePutDTO
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
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage must be positive!")]
        public int Mileage { get; set; }
    }
}
