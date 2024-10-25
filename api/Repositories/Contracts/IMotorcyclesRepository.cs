using api.DTOs.Motorcycle;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<List<Motorcycle>> GetAllAsync();
        Task<Motorcycle?> GetByIdAsync(int id);
        Task CreateAsync(Motorcycle model);
        Task UpdateAsync(int id, Motorcycle model, MotorcyclePutDTO dto);
        Task DeleteAsync(Motorcycle model);
    }
}
