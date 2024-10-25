using api.Data;
using api.DTOs.Motorcycle;
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

        public async Task<List<Motorcycle>> GetAllAsync()
        {
            return await _context.Motorcycles.ToListAsync();
        }

        public async Task<Motorcycle?> GetByIdAsync(int id)
        {
            var model = await _context.Motorcycles.FindAsync(id);

            return model;
        }

        public async Task CreateAsync(Motorcycle model)
        {
            await _context.Motorcycles.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Motorcycle model, MotorcyclePutDTO dto)
        {
            _context.Entry(model).CurrentValues
                    .SetValues(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Motorcycle model)
        {
            _context.Motorcycles.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
