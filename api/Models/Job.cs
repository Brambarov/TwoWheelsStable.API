using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int Mileage { get; set; }
        public int DueMileage { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public Guid MotorcycleId { get; set; }
        public Motorcycle? Motorcycle { get; set; }
        public bool IsDeleted { get; set; }
    }
}
