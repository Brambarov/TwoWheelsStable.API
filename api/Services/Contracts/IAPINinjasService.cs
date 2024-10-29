using api.Models;

namespace api.Services.Contracts
{
    public interface IAPINinjasService
    {
        Task<Specs?> GetSpecsAsync(string make, string model);
    }
}
