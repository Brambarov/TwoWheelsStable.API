using api.Models;

namespace api.Repositories.Contracts
{
    public interface ISpecsRepository
    {
        Task<IEnumerable<Specs>> GetAsync(string make, string model);
        Task<Guid> CreateAsync(Specs model);
        Task DeleteAsync(Specs model);
    }
}
