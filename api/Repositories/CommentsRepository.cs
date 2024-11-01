using api.Data;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentsRepository(ApplicationDbContext context) : ICommentsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(c => c.User)
                                          .ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int? id)
        {
            return await _context.Comments.Include(c => c.User)
                                          .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<int?> CreateAsync(Comment model)
        {
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out int id);

            return id;
        }

        public async Task UpdateAsync(Comment model, Comment update)
        {
            _context.Entry(model).CurrentValues
                    .SetValues(update);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment model)
        {
            _context.Comments.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
