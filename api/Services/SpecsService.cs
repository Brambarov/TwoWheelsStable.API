using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class SpecsService(ISpecsRepository specsRepository,
                              IAPINinjasService apiNinjasService) : ISpecsService
    {
        private readonly ISpecsRepository _specsRepository = specsRepository;
        private readonly IAPINinjasService _apiNinjasService = apiNinjasService;

        public async Task<Specs?> GetOrCreateAsync(string make, string model, int year)
        {
            var specsDb = (await _specsRepository.GetAsync(make, model)).Where(s => s.Year < year)
                                                                        .OrderBy(s => s.Year)
                                                                        .LastOrDefault();

            var specsNinja = await _apiNinjasService.GetAsync(make, model, year);

            if (specsDb != null && specsNinja != null)
            {
                if (specsDb.Year == specsNinja.Year)
                {
                    return specsDb;
                }
            }

            return await _specsRepository.CreateAsync();
        }
    }
}
