using api.Data;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MotorcyclesRepository : IMotorcyclesRepository
    {
        private readonly ApplicationDbContext _context;

        public MotorcyclesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motorcycle>> GetAllAsync(MotorcycleQuery query)
        {
            var models = _context.Motorcycles.Include(m => m.Comments)
                                             .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                models = models.Where(m => m.Make.Contains(query.Make));
            }

            if (!string.IsNullOrWhiteSpace(query.Model))
            {
                models = models.Where(m => m.Make.Contains(query.Model));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Make", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(m => m.Make) : models.OrderBy(m => m.Id);
                }
                if (query.SortBy.Equals("Model", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(m => m.Model) : models.OrderBy(m => m.Id);
                }
            }

            return await models.ToListAsync();
        }

        public async Task<Motorcycle?> GetByIdAsync(int? id)
        {
            return await _context.Motorcycles.Include(m => m.Comments)
                                             .FirstOrDefaultAsync(m => m.Id.Equals(id));
        }

        public async Task<int?> CreateAsync(Motorcycle model)
        {
            await _context.Motorcycles.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out int id);

            return id;
        }

        public async Task UpdateAsync(Motorcycle model, Motorcycle update)
        {
            _context.Entry(model).CurrentValues
                    .SetValues(update);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Motorcycle model)
        {
            _context.Motorcycles.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Motorcycles.AnyAsync(m => m.Id.Equals(id));
        }
    }
}
