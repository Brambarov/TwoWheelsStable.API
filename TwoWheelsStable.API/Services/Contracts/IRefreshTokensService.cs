using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Services.Contracts
{
    public interface IRefreshTokensService
    {
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task<RefreshToken> CreateAsync(string userId, string ipAddress);
        Task UpdateAsync(RefreshToken refreshToken);
        Task DeleteAsync(RefreshToken refreshToken);

    }
}
