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
    }
}
