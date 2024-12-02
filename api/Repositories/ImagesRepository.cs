using api.Data;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ImagesRepository(ApplicationDbContext context) : IImagesRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Image>> GetByMotorcycleIdAsync(int motorcycleId)
        {
            return await _context.Images.Where(i => i.MotorcycleId == motorcycleId)
                                        .ToListAsync();
        }

        public async Task<int?> CreateAsync(Image model)
        {
            await _context.Images.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out int id);

            return id;
        }

        public async Task DeleteAsync(Image model)
        {
            model.IsDeleted = true;

            _context.Images.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
