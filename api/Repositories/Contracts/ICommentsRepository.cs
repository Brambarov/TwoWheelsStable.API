using api.Models;

namespace api.Repositories.Contracts
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
    }
}
