namespace api.DTOs.Comment
{
    public class CommentGetDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? MotorcycleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
    }
}
