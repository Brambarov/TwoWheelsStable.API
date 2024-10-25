using api.DTOs.Motorcycle;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<List<Motorcycle>> GetAllAsync();
        Task<Motorcycle?> GetByIdAsync(int id);
        Task CreateAsync(Motorcycle model);
        Task<Motorcycle?> UpdateAsync(int id, MotorcyclePutDTO dto);
        Task DeleteAsync(int id);
    }
}
