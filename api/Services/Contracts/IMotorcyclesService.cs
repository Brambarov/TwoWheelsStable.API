using api.DTOs.Motorcycle;

namespace api.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync();
        Task<MotorcycleGetDTO?> GetByIdAsync(int id);
        Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto);
        Task<MotorcycleGetDTO?> UpdateAsync(int id, MotorcyclePutDTO dto);
        Task<MotorcycleGetDTO?> DeleteAsync(int id);
    }
}
