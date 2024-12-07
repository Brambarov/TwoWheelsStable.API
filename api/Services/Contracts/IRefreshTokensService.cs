using api.Models;

namespace api.Services.Contracts
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
