using api.DTOs.Comment;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetAllAsync();
    }
}
