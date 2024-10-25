using api.Models;

namespace api.Repositories.Contracts
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int? id);
        Task<int?> CreateAsync(Comment model);
        Task UpdateAsync(Comment model, Comment update);
        Task DeleteAsync(Comment model);
    }
}
