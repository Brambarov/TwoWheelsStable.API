using api.DTOs.Motorcycle;
using api.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query, IUrlHelper uriHelper);
        Task<IEnumerable<MotorcycleGetDTO>> GetByUserIdAsync(string userId, IUrlHelper uriHelper);
        Task<MotorcycleGetDTO?> GetByIdAsync(Guid id, IUrlHelper uriHelper);
        Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto, IUrlHelper uriHelper);
        Task<MotorcycleGetDTO?> UpdateAsync(Guid id, MotorcyclePutDTO dto, IUrlHelper uriHelper);
        Task DeleteAsync(Guid id);
    }
}
