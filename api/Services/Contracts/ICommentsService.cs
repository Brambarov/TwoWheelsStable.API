using api.DTOs.Comment;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(int motorcycleId, CommentQuery query);
        Task<CommentGetDTO?> GetByIdAsync(int id);
        Task<CommentGetDTO?> CreateAsync(int motorcycleId, CommentPostDTO dto);
        Task<CommentGetDTO?> UpdateAsync(int id, CommentPutDTO dto);
        Task DeleteAsync(int id);
    }
}
