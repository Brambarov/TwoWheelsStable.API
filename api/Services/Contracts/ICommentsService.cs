using api.DTOs.Comment;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetAllAsync();
        Task<CommentGetDTO?> GetByIdAsync(int id);
        Task<CommentGetDTO?> CreateAsync(int motorcycleId, CommentPostDTO dto);
        Task<CommentGetDTO?> UpdateAsync(int id, CommentPutDTO dto);
        Task<CommentGetDTO?> DeleteAsync(int id);
    }
}
