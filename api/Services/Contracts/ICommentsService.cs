using api.DTOs.Comment;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId, CommentQuery query);
        Task<CommentGetDTO?> GetByIdAsync(Guid id);
        Task<CommentGetDTO?> CreateAsync(Guid motorcycleId, CommentPostDTO dto);
        Task<CommentGetDTO?> UpdateAsync(Guid id, CommentPutDTO dto);
        Task DeleteAsync(Guid id);
    }
}
