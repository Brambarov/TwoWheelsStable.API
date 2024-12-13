using api.DTOs.Comment;
using api.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId, CommentQuery query, IUrlHelper urlHelper);
        Task<CommentGetDTO?> GetByIdAsync(Guid id, IUrlHelper urlHelper);
        Task<CommentGetDTO?> CreateAsync(Guid motorcycleId, CommentPostDTO dto, IUrlHelper urlHelper);
        Task<CommentGetDTO?> UpdateAsync(Guid id, CommentPutDTO dto, IUrlHelper urlHelper);
        Task DeleteAsync(Guid id);
    }
}
