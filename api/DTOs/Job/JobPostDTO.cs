using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Job
{
    public class JobPostDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int DueMileage { get; set; }
    }
}
