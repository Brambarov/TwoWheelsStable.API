namespace api.DTOs.Comment
{
    public class CommentGetDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
    }
}
