using api.Models;

namespace api.Repositories.Contracts
{
    public interface ISpecsRepository
    {
        Task<Specs> GetAsync(string make, string model, int year);
    }
}
