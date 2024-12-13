using api.Data;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Repositories
{
    public class CommentsRepository(ApplicationDbContext context) : ICommentsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Comment>> GetByMotorcycleIdAsync(Guid motorcycleId,
                                                                          CommentQuery query)
        {
            var models = _context.Comments.Where(c => c.MotorcycleId.Equals(motorcycleId))
                                                .Include(c => c.User)
                                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                models = models.Where(c => c.Title.Contains(query.Title));
            }

            if (!string.IsNullOrWhiteSpace(query.Content))
            {
                models = models.Where(c => c.Content.Contains(query.Content));
            }

            models = query.IsDescending ? models.OrderByDescending(j => j.CreatedOn) : models.OrderBy(j => j.CreatedOn);

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await models.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            return await _context.Comments.Include(c => c.User)
                                          .FirstOrDefaultAsync(c => c.Id.Equals(id))
                   ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError,
                                                                   "Comment",
                                                                   "Id",
                                                                   id.ToString()));
        }

        public async Task<Guid> CreateAsync(Comment model)
        {
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out Guid id);

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
            model.IsDeleted = true;

            _context.Comments.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
