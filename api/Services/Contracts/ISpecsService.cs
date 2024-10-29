using api.Models;

namespace api.Services.Contracts
{
    public interface ISpecsService
    {
        Task<Specs?> GetOrCreateAsync(string make, string model, int year);
    }
}
