namespace api.Helpers.Queries
{
    public class CommentQuery
    {
        public string? Title { get; set; } = null;
        public string? Content { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
