namespace api.DTOs.Comment
{
    public class CommentGetDTO
    {
        public string Href { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string UserHref { get; set; } = string.Empty;
    }
}
