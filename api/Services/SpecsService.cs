using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class SpecsService : ISpecsService
    {
        private readonly ISpecsRepository _specsRepository;
        private readonly IAPINinjasService _aPINinjasService;

        public SpecsService(ISpecsRepository specsRepository,
                            IAPINinjasService aPINinjasService)
        {
            _specsRepository = specsRepository;
            _aPINinjasService = aPINinjasService;
        }

        public async Task<Specs?> GetOrCreateAsync(string make, string model, int year)
        {
            var specs = await _specsRepository.GetAsync(make, model, year);

            if (specs != null) return specs;

            specs = await _aPINinjasService.GetAsync(make, model, year);

            throw new NotImplementedException();
        }
    }
}
