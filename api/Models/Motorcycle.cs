using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Motorcycles")]
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        //public int? UserId { get; set; }
        //public User? User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
