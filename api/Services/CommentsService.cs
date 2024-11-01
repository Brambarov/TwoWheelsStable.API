using api.DTOs.Comment;
using api.Helpers.Extensions;
using api.Helpers.Mappers;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class CommentsService(UserManager<User> userManager,
                                 IHttpContextAccessor httpContextAccessor,
                                 ICommentsRepository commentsRepository,
                                 IMotorcyclesRepository motorcyclesRepository) : ICommentsService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ICommentsRepository _commentsRepository = commentsRepository;
        private readonly IMotorcyclesRepository _motorcyclesRepository = motorcyclesRepository;

        public async Task<IEnumerable<CommentGetDTO>> GetAllAsync()
        {
            var models = await _commentsRepository.GetAllAsync();

            return models.Select(c => c.ToGetDTO());
        }

        public async Task<CommentGetDTO?> GetByIdAsync(int id)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<CommentGetDTO?> CreateAsync(int motorcycleId, CommentPostDTO dto)
        {
            if (!await _motorcyclesRepository.Exists(motorcycleId)) throw new ApplicationException($"Motorcycle with Id {motorcycleId} does not exist!");

            var httpContext = _httpContextAccessor.HttpContext ?? throw new ApplicationException("Http connection failed!");

            var userName = httpContext.User.GetUsername();

            if (string.IsNullOrWhiteSpace(userName)) throw new ApplicationException($"Username {userName} is invalid!");

            var user = await _userManager.FindByNameAsync(userName) ?? throw new ApplicationException($"User with username {userName} does not exist!");

            var userId = user.Id;

            var model = dto.FromPostDTO(userId, motorcycleId);

            var id = await _commentsRepository.CreateAsync(model);

            model = await _commentsRepository.GetByIdAsync(id);
            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<CommentGetDTO?> UpdateAsync(int id, CommentPutDTO dto)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model == null) return null;

            // TODO: validate model input data
            var update = new Comment().FromPutDTO(id, model.MotorcycleId, dto);

            await _commentsRepository.UpdateAsync(model, update);

            model = await _commentsRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<CommentGetDTO?> DeleteAsync(int id)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model == null) return null;

            await _commentsRepository.DeleteAsync(model);

            return model.ToGetDTO();
        }
    }
}
