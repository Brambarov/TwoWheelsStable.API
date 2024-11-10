using api.DTOs.Motorcycle;
using api.Helpers.Extensions;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class MotorcyclesService(UserManager<User> userManager,
                                    IHttpContextAccessor httpContextAccessor,
                                    ISpecsService specsService,
                                    IMotorcyclesRepository motorcyclesRepository) : IMotorcyclesService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ISpecsService _specsService = specsService;
        private readonly IMotorcyclesRepository _motorcyclesRepository = motorcyclesRepository;

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
            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var httpContext = _httpContextAccessor.HttpContext ?? throw new ApplicationException("Http connection failed!");

            var userName = httpContext.User.GetUserName();

            if (string.IsNullOrWhiteSpace(userName)) throw new ApplicationException($"Username {userName} is invalid!");

            var user = await _userManager.FindByNameAsync(userName) ?? throw new ApplicationException($"User with username {userName} does not exist!");

            var id = await _motorcyclesRepository.CreateAsync(dto.FromPostDTO(specsId, user.Id));

            var model = await _motorcyclesRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<MotorcycleGetDTO?> UpdateAsync(int motorcycleId, MotorcyclePutDTO dto)
        {
            var model = await _motorcyclesRepository.GetByIdAsync(motorcycleId);

            if (model == null) return null;

            var specsId = await _specsService.GetOrCreateAsync(dto.Make, dto.Model, dto.Year);

            var update = dto.FromPutDTO(motorcycleId, specsId);

            await _motorcyclesRepository.UpdateAsync(model, update);

            model = await _motorcyclesRepository.GetByIdAsync(motorcycleId);

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
