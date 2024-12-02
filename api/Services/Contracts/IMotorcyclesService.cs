﻿using api.DTOs.Motorcycle;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query);
        Task<IEnumerable<MotorcycleGetDTO>> GetByUserIdAsync(string userId);
        Task<MotorcycleGetDTO?> GetByIdAsync(int id);
        Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto, List<IFormFile> images);
        Task<MotorcycleGetDTO?> UpdateAsync(int id, MotorcyclePutDTO dto);
        Task DeleteAsync(int id);
    }
}
