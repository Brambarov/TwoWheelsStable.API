using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using System.Security.Cryptography;

namespace api.Services
{
    public class RefreshTokensService(IRefreshTokensRepository refreshTokensRepository) : IRefreshTokensService
    {
        private readonly IRefreshTokensRepository _refreshTokensRepository = refreshTokensRepository;

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _refreshTokensRepository.GetByTokenAsync(token);
        }

        public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId)
        {
            return await _refreshTokensRepository.GetByUserIdAsync(userId);
        }

        public async Task<RefreshToken> CreateAsync(string userId, string ipAddress)
        {
            var refreshToken = GenerateRefreshToken(userId, ipAddress);

            await _refreshTokensRepository.CreateAsync(refreshToken);

            return refreshToken;
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            await _refreshTokensRepository.UpdateAsync(refreshToken);
        }

        public async Task DeleteAsync(RefreshToken refreshToken)
        {
            await _refreshTokensRepository.DeleteAsync(refreshToken);
        }

        private static RefreshToken GenerateRefreshToken(string userId, string ipAddress)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                UserId = userId,
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }
    }
}
