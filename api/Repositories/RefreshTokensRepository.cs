using api.Data;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Repositories
{
    public class RefreshTokensRepository(ApplicationDbContext context) : IRefreshTokensRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token.Equals(token) && !rt.IsRevoked)
                   ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError,
                                                                   "Refresh Token",
                                                                   "Token",
                                                                   token));
        }

        public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId)
        {
            return await _context.RefreshTokens.Where(rt => rt.UserId.Equals(userId) && !rt.IsRevoked)
                                               .ToListAsync();
        }

        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            _context.Entry(refreshToken).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
