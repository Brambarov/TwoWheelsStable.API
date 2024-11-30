using api.Data;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Repositories
{
    public class MotorcyclesRepository(ApplicationDbContext context) : IMotorcyclesRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Motorcycle>> GetAllAsync(MotorcycleQuery query)
        {
            var models = _context.Motorcycles.Include(m => m.Specs)
                                             .Include(m => m.User)
                                             .Include(m => m.Schedule)
                                             .Include(m => m.Comments)
                                             .ThenInclude(c => c.User)
                                             .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Make))
            {
                models = models.Where(m => m.Make.Contains(query.Make));
            }

            if (!string.IsNullOrWhiteSpace(query.Model))
            {
                models = models.Where(m => m.Model.Contains(query.Model));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Make", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(m => m.Make) : models.OrderBy(m => m.Make);
                }
                if (query.SortBy.Equals("Model", StringComparison.OrdinalIgnoreCase))
                {
                    models = query.IsDescending ? models.OrderByDescending(m => m.Model) : models.OrderBy(m => m.Model);
                }
            }
            else
            {
                models = query.IsDescending ? models.OrderByDescending(m => m.Id) : models.OrderBy(m => m.Id);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await models.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Motorcycle> GetByIdAsync(int? id)
        {
            return await _context.Motorcycles.Include(m => m.Specs)
                                             .Include(m => m.User)
                                             .Include(m => m.Schedule)
                                             .Include(m => m.Comments)
                                             .ThenInclude(c => c.User)
                                             .FirstOrDefaultAsync(m => m.Id.Equals(id))
                   ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError,
                                                                   "Motorcycle",
                                                                   "Id",
                                                                   id.ToString())); ;
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
            model.IsDeleted = true;

            _context.Motorcycles.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
