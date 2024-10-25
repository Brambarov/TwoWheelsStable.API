using api.Data;
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

        public async Task<IEnumerable<Motorcycle>> GetAllAsync()
        {
            return await _context.Motorcycles.Include(m => m.Comments)
                                             .ToListAsync();
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
