using api.Models;
using api.Services.Contracts;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace api.Services
{
    public class APINinjasService(HttpClient httpClient,
                                  IConfiguration configuration) : IAPINinjasService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;

        public async Task<Specs?> GetAsync(string make, string model, int year)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _configuration["APINinjasKey"]);

                var response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}&year={year}");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var specsList = JsonConvert.DeserializeObject<List<Specs>>(jsonResponse);

                if (specsList == null || specsList.Count == 0)
                {
                    response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}");

                    response.EnsureSuccessStatusCode();

                    jsonResponse = await response.Content.ReadAsStringAsync();
                    specsList = JsonConvert.DeserializeObject<List<Specs>>(jsonResponse);

                    if (specsList == null || specsList.Count == 0) throw new ApplicationException("Specs not found on API Ninjas!");
                }

                var specs = specsList.Where(s => s.Year < year
                                        && s.Make.Equals(make, StringComparison.OrdinalIgnoreCase)
                                        && s.Model.Equals(model, StringComparison.OrdinalIgnoreCase))
                            .OrderBy(s => s.Year)
                            .LastOrDefault();

                if (specs != null)
                {
                    var unspacedSlashPattern = new Regex(@"(?<!\s)/(?!\s)");
                    var doubleBracePattern = new Regex(@"\)\)");
                    var extraSpacesPattern = new Regex(@"\s{2,}");
                    var middleSemicolonPattern = new Regex(@"(?<=\s*[\)]);\s*(?=[\s\w()])");

                    foreach (var property in specs.GetType().GetProperties())
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            var value = property.GetValue(specs) as string;

                            if (value != null)
                            {
                                var formattedValue = unspacedSlashPattern.Replace(value, " / ");
                                formattedValue = doubleBracePattern.Replace(formattedValue, ")");
                                formattedValue = extraSpacesPattern.Replace(formattedValue, " ");
                                formattedValue = middleSemicolonPattern.Replace(formattedValue, ". ");
                                formattedValue = formattedValue.Trim();
                                property.SetValue(specs, formattedValue);
                            }
                        }
                    }

                    return specs;
                }

                throw new ApplicationException("Specs not found on API Ninjas!");
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
