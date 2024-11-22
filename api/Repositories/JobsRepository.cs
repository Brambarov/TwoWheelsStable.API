using api.Data;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class JobsRepository(ApplicationDbContext context) : IJobsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Job>> GetAllByMotorcycleIdAsync(int motorcycleId,
                                                        JobQuery query)
        {
            var models = _context.Jobs.Where(j => j.MotorcycleId.Equals(motorcycleId)).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                models = models.Where(j => j.Title.Contains(query.Title));
            }

            if (!string.IsNullOrWhiteSpace(query.Description))
            {
                models = models.Where(j => j.Description.Contains(query.Description));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Cost", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(j => j.Cost) : models.OrderBy(m => m.Id);
                }
                if (query.SortBy.Equals("DueDate", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(j => j.DueDate) : models.OrderBy(m => m.Id);
                }
                if (query.SortBy.Equals("Mileage", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(j => j.Mileage) : models.OrderBy(m => m.Id);
                }
                if (query.SortBy.Equals("DueMileage", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(j => j.DueMileage) : models.OrderBy(m => m.Id);
                }
            }
            else
            {
                models = query.IsDescending ? models.OrderByDescending(j => j.Date) : models.OrderBy(j => j.Date);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await models.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int? id)
        {
            return await _context.Jobs.FirstOrDefaultAsync(j => j.Id.Equals(id));
        }

        public async Task<int?> CreateAsync(Job model)
        {
            await _context.Jobs.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out int id);

            return id;
        }

        public async Task UpdateAsync(Job model,
                                      Job update)
        {
            _context.Entry(model).CurrentValues
                    .SetValues(update);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Job model)
        {
            model.IsDeleted = true;

            _context.Jobs.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Jobs.AnyAsync(m => m.Id.Equals(id));
        }
    }
}
