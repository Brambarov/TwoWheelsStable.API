using api.Models;

namespace api.Services.Contracts
{
    public interface IAPINinjasService
    {
        Task<Specs?> GetAsync(string make, string model, int year);
    }
}
