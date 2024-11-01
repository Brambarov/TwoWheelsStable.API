using api.Models;

namespace api.Repositories.Contracts
{
    public interface ISpecsRepository
    {
        Task<IEnumerable<Specs>> GetAsync(string make, string model);
        Task<int?> CreateAsync(Specs model);
    }
}
