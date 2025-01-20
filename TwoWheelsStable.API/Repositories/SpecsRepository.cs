using Microsoft.EntityFrameworkCore;
using TwoWheelsStable.API.Data;
using TwoWheelsStable.API.Models;
using TwoWheelsStable.API.Repositories.Contracts;

namespace TwoWheelsStable.API.Repositories
{
    public class SpecsRepository(ApplicationDbContext context) : ISpecsRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Specs>> GetAsync(string make, string model)
        {
            return await _context.Specs.Where(s => s.Make == make && s.Model == model)
                                       .ToListAsync();
        }

        public async Task<Guid> CreateAsync(Specs model)
        {
            await _context.Specs.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out Guid id);

            return id;
        }

        public async Task DeleteAsync(Specs model)
        {
            model.IsDeleted = true;

            _context.Specs.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
