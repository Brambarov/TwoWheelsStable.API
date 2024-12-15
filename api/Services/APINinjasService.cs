using api.Helpers.Configs;
using api.Models;
using api.Services.Contracts;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class APINinjasService(HttpClient httpClient, APINinjasConfig config) : IAPINinjasService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = config.APIKey;

        public async Task<Specs> GetAsync(string make, string model, int year)
        {
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);

            var specsList = await TryGetSpecsAsync(make, model)
                            ?? await TryGetSpecsAsync(make, NormalizeString(model))
                            ?? await TryGetSpecsAsync(make, AddSpaces(model));

            if (specsList == null || specsList.Count == 0) throw new ApplicationException(string.Format(NotFoundOnError, "Specs", "API Ninjas"));

            var specs = specsList.Where(s => s.Year <= year
                                             && s.Make.Equals(make, StringComparison.OrdinalIgnoreCase)
                                             && s.Model.Equals(model, StringComparison.OrdinalIgnoreCase))
                                 .OrderBy(s => s.Year)
                                 .LastOrDefault()
                        ?? specsList.Where(s => s.Year <= year)
                                    .OrderBy(s => s.Year)
                                    .LastOrDefault();

            if (specs != null)
            {
                return FormatSpecs(specs);
            }

            throw new ApplicationException(string.Format(NotFoundOnError, "Specs", "API Ninjas"));
        }

        private async Task<List<Specs>?> TryGetSpecsAsync(string make, string model)
        {
            var response = await _httpClient.GetAsync($"https://api.api-ninjas.com/v1/motorcycles?make={make}&model={model}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var specsList = JsonConvert.DeserializeObject<List<Specs>>(jsonResponse);

            if (specsList == null || specsList.Count == 0)
            {
                return null;
            }

            return specsList;
        }

        private static Specs FormatSpecs(Specs specs)
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

        private static string NormalizeString(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return s.Replace(" ", "").ToUpperInvariant();
        }

        private static string AddSpaces(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            return Regex.Replace(s, @"(?<=[A-Za-z])(?=\d)|(?=\d)(?=[A-Z-a-z])", " ");
        }
    }
}
