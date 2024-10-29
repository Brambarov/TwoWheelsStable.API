using api.DTOs.Comment;
using api.Models;

namespace api.DTOs.Motorcycle
{
    public class MotorcycleGetDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public Specs? Specs { get; set; }
        public List<CommentGetDTO> Comments { get; set; } = new List<CommentGetDTO>();
    }
}
