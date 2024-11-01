using api.Data;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SpecsRepository(ApplicationDbContext context,
                                 IAPINinjasService aPINinjasService) : ISpecsRepository
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IAPINinjasService _aPINinjasService = aPINinjasService;

        public async Task<IEnumerable<Specs>> GetAsync(string make, string model)
        {
            return await _context.Specs.Where(s => s.Make == make && s.Model == model)
                                       .ToListAsync();
        }

        public Task<Specs> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
