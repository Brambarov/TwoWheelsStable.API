using api.DTOs.Motorcycle;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class MotorcyclesService(IUsersService usersService,
                                    IImagesService imagesService,
                                    IMotorcyclesRepository motorcyclesRepository,
                                    ISpecsService specsService) : IMotorcyclesService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IImagesService _imagesService = imagesService;
        private readonly ISpecsService _specsService = specsService;
        private readonly IMotorcyclesRepository _motorcyclesRepository = motorcyclesRepository;

        public async Task<IEnumerable<MotorcycleGetDTO>> GetAllAsync(MotorcycleQuery query)
        {
            var dtos = (await _motorcyclesRepository.GetAllAsync(query)).Select(m => m.ToGetDTO());

            return dtos;
        }

        public async Task<IEnumerable<MotorcycleGetDTO>> GetByUserIdAsync(string userId)
        {
            var dtos = (await _motorcyclesRepository.GetByUserIdAsync(userId)).Select(m => m.ToGetDTO());

            return dtos;
        }

        public async Task<MotorcycleGetDTO?> GetByIdAsync(Guid id)
        {
            var dto = (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();

            return dto;
        }

        public async Task<MotorcycleGetDTO?> CreateAsync(MotorcyclePostDTO dto)
        {
            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var userId = _usersService.GetCurrentUserId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _motorcyclesRepository.CreateAsync(dto.FromPostDTO(specsId, userId));

            return (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> UpdateAsync(Guid id, MotorcyclePutDTO dto)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            var userId = _usersService.GetCurrentUserId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var update = dto.FromPutDTO(model, specsId);

            await _motorcyclesRepository.UpdateAsync(model, update);

            return (await _motorcyclesRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(id);

            var userId = _usersService.GetCurrentUserId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            await _motorcyclesRepository.DeleteAsync(model);
        }
    }
}
