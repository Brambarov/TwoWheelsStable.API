using api.Data;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class SpecsRepository : ISpecsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IAPINinjasService _aPINinjasService;

        public SpecsRepository(ApplicationDbContext context,
                               IAPINinjasService aPINinjasService)
        {
            _context = context;
            _aPINinjasService = aPINinjasService;
        }

        public async Task<Specs> GetAsync(string make, string model, int year)
        {
            var specs = await _context.Specs.FirstOrDefaultAsync(s => s.make == make && s.model == model && s.year == year);

            if (specs != null) return specs;

            throw new ApplicationException("Specs not found!");
        }
    }
}
