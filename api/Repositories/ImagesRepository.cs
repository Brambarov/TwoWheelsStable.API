using api.Data;
using api.Models;
using api.Repositories.Contracts;

namespace api.Repositories
{
    public class ImagesRepository(ApplicationDbContext context) : IImagesRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<IEnumerable<Image>> GetByMotorcycleIdAsync(int motorcycleId)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> CreateAsync(Image model)
        {
            await _context.Images.AddAsync(model);
            await _context.SaveChangesAsync();

            _context.Entry(model).CurrentValues.TryGetValue("Id", out int id);

            return id;
        }

        public Task DeleteAsync(Image model)
        {
            throw new NotImplementedException();
        }
    }
}
