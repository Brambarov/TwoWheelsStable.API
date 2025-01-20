using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Repositories.Contracts
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllAsync(UserQuery query);
        Task<User> GetByIdAsync(string id);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByRefreshTokenAsync(string refreshToken);
        Task<string> CreateAsync(User model, string password);
        Task UpdateAsync(User model);
        Task DeleteAsync(User model);
    }
}
