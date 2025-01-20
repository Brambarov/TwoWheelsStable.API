using Microsoft.AspNetCore.Mvc;
using TwoWheelsStable.API.DTOs.Comment;
using TwoWheelsStable.API.Helpers.Queries;

namespace TwoWheelsStable.API.Services.Contracts
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
