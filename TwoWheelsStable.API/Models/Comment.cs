using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
        public User? User { get; set; }
        public Guid MotorcycleId { get; set; }
        public Motorcycle? Motorcycle { get; set; }
        public bool IsDeleted { get; set; }
    }
}
