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

        public async Task<string?> FindMotorcycleByMakeAndModel(string make, string model)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _configuration["APINinjasKey"]);

                var response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var motorcyclesTechSpecs = JsonConvert.DeserializeObject<List<dynamic>>(jsonResponse);

                if (motorcyclesTechSpecs == null || !motorcyclesTechSpecs.Any()) return null;

                return JsonConvert.SerializeObject(motorcyclesTechSpecs.FirstOrDefault());
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
