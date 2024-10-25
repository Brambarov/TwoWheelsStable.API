using api.DTOs.Motorcycle;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query);
        Task<MotorcycleGetDTO?> GetByIdAsync(int id);
        Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto);
        Task<MotorcycleGetDTO?> UpdateAsync(int id, MotorcyclePutDTO dto);
        Task<MotorcycleGetDTO?> DeleteAsync(int id);
    }
}
