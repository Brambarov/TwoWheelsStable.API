namespace api.DTOs.Comment
{
    public class CommentGetDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}
