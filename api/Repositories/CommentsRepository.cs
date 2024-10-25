using api.Data;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int? id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<int?> CreateAsync(Comment model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Comment model, Comment update)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Comment model)
        {
            throw new NotImplementedException();
        }
    }
}
