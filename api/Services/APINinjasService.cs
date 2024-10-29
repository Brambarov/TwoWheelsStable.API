using api.Models;
using api.Services.Contracts;
using Newtonsoft.Json;

namespace api.Services
{
    public class APINinjasService : IAPINinjasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public APINinjasService(HttpClient httpClient,
                                IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Specs?> GetAsync(string make, string model, int year)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _configuration["APINinjasKey"]);

                var response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}&year={year}");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var specs = JsonConvert.DeserializeObject<List<Specs>>(jsonResponse);

                if (specs == null || specs.Count == 0)
                {
                    response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}");

                    response.EnsureSuccessStatusCode();

                    jsonResponse = await response.Content.ReadAsStringAsync();
                    specs = JsonConvert.DeserializeObject<List<Specs>>(jsonResponse);

                    if (specs == null || specs.Count == 0) return null;
                }

                return specs.Where(s => s.year < year)
                            .OrderBy(s => s.year)
                            .LastOrDefault();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occured while calling an external API!", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error occurred!", ex);
            }
        }
    }
}
