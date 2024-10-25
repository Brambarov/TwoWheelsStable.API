using api.DTOs.Comment;

namespace api.DTOs.Motorcycle
{
    public class MotorcycleGetDTO
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public List<CommentGetDTO> Comments { get; set; } = new List<CommentGetDTO>();
    }
}
