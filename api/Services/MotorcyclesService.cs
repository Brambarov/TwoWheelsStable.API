using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class MotorcyclesService(IUsersService usersService,
                                    IMotorcyclesRepository motorcyclesRepository,
                                    ISpecsService specsService) : IMotorcyclesService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly ISpecsService _specsService = specsService;
        private readonly IMotorcyclesRepository _motorcyclesRepository = motorcyclesRepository;

        public async Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query)
        {
            return (await _motorcyclesRepository.GetAllAsync(query)).Select(m => m.ToGetDTO());
        }

        public async Task<IEnumerable<MotorcycleGetDTO>> GetByUserIdAsync(string userId)
        {
            return (await _motorcyclesRepository.GetByUserIdAsync(userId)).Select(m => m.ToGetDTO());
        }

        public async Task<MotorcycleGetDTO?> GetByIdAsync(int id)
        {
            return (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto)
        {
            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var userId = _usersService.GetCurrentUserId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _motorcyclesRepository.CreateAsync(dto.FromPostDTO(specsId, userId));

            return (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> UpdateAsync(int id, MotorcyclePutDTO dto)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            var userId = _usersService.GetCurrentUserId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var update = dto.FromPutDTO(model, specsId);

            await _motorcyclesRepository.UpdateAsync(model, update);

            return (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            var userId = _usersService.GetCurrentUserId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            await _motorcyclesRepository.DeleteAsync(model);
        }
    }
}
