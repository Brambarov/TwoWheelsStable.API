using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class MotorcyclesService : IMotorcyclesService
    {
        private readonly IMotorcyclesRepository _motorcyclesRepository;

        public MotorcyclesService(IMotorcyclesRepository motorcyclesRepository)
        {
            _motorcyclesRepository = motorcyclesRepository;
        }

        public async Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync()
        {
            var models = await _motorcyclesRepository.GetAllAsync();

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
            var update = new Motorcycle().FromPutDTO(id, dto);

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
