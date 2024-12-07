using api.DTOs.Comment;
using api.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId, CommentQuery query);
        Task<CommentGetDTO?> GetByIdAsync(Guid id);
        Task<CommentGetDTO?> CreateAsync(Guid motorcycleId, CommentPostDTO dto, IUrlHelper urlHelper);
        Task<CommentGetDTO?> UpdateAsync(Guid id, CommentPutDTO dto);
        Task DeleteAsync(Guid id);
    }
}
