using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Comment
{
    public class CommentPutDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
