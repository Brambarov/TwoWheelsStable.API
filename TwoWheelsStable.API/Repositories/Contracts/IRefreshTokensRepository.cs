using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Repositories.Contracts
{
    public interface IRefreshTokensRepository
    {
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task CreateAsync(RefreshToken refreshToken);
        Task UpdateAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);
    }
}
