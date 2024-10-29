﻿using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class MotorcyclesService : IMotorcyclesService
    {
        private readonly ISpecsService _specsService;
        private readonly IMotorcyclesRepository _motorcyclesRepository;

        public MotorcyclesService(ISpecsService specsService,
                                  IMotorcyclesRepository motorcyclesRepository)
        {
            _specsService = specsService;
            _motorcyclesRepository = motorcyclesRepository;
        }

        public async Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query)
        {
            var models = await _motorcyclesRepository.GetAllAsync(query);

            return models.Select(m => m.ToGetDTO());
        }

        public async Task<MotorcycleGetDTO?> GetByIdAsync(int id)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto)
        {
            var id = await _motorcyclesRepository.CreateAsync(dto.FromPostDTO());



            var model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> UpdateAsync(int id, MotorcyclePutDTO dto)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            // TODO: validate model input data
            var update = dto.FromPutDTO(id);

            await _motorcyclesRepository.UpdateAsync(model, update);

            model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> DeleteAsync(int id)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            await _motorcyclesRepository.DeleteAsync(model);

            return model.ToGetDTO();
        }
    }
}
