using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class SpecsService(ISpecsRepository specsRepository,
                              IAPINinjasService aPINinjasService) : ISpecsService
    {
        private readonly ISpecsRepository _specsRepository = specsRepository;
        private readonly IAPINinjasService _APINinjasService = aPINinjasService;

        public async Task<Specs?> GetOrCreateAsync(string make, string model, int year)
        {
            var specsDb = (await _specsRepository.GetAsync(make, model)).Where(s => s.Year < year)
                                                                      .OrderBy(s => s.Year)
                                                                      .LastOrDefault();

            var specsNinja = await _APINinjasService.GetAsync(make, model, year);

            if (specsDb.Year == specsNinja.Year)
            {
                return specsDb;
            }

            return await _specsRepository.CreateAsync();
        }
    }
}
