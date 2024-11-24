using api.Helpers.Queries;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<IEnumerable<Motorcycle>> GetAllAsync(MotorcycleQuery query);
        Task<Motorcycle> GetByIdAsync(int? id);
        Task<int?> CreateAsync(Motorcycle model);
        Task UpdateAsync(Motorcycle model, Motorcycle update);
        Task DeleteAsync(Motorcycle model);
        Task<bool> Exists(int id);
    }
}
