using api.DTOs.Comment;
using api.Helpers.Mappers;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMotorcyclesRepository _motorcyclesRepository;

        public CommentsService(ICommentsRepository commentsRepository,
                               IMotorcyclesRepository motorcyclesRepository)
        {
            _commentsRepository = commentsRepository;
            _motorcyclesRepository = motorcyclesRepository;
        }

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

            var id = await _commentsRepository.CreateAsync(dto.FromPostDTO(motorcycleId));

            var model = await _commentsRepository.GetByIdAsync(id);

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
