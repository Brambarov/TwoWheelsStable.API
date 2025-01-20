using api.Helpers.Queries;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetByMotorcycleIdAsync(Guid motorcycleId, CommentQuery query);
        Task<Comment> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Comment model);
        Task UpdateAsync(Comment model, Comment update);
        Task DeleteAsync(Comment model);
    }
}
