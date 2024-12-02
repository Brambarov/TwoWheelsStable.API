using api.DTOs.Motorcycle;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query);
        Task<IEnumerable<MotorcycleGetDTO>> GetByUserIdAsync(string userId);
        Task<MotorcycleGetDTO?> GetByIdAsync(Guid id);
        Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto);
        Task<MotorcycleGetDTO?> UpdateAsync(Guid id, MotorcyclePutDTO dto);
        Task DeleteAsync(Guid id);
    }
}
