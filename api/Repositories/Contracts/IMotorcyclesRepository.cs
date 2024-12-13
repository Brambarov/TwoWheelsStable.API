using api.Helpers.Queries;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync(MotorcycleQuery query);
        Task<IEnumerable<Motorcycle>> GetByUserIdAsync(string userId);
        Task<Motorcycle> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Motorcycle model);
        Task UpdateAsync(Motorcycle model, Motorcycle update);
        Task DeleteAsync(Motorcycle model);
    }
}
