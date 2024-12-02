using api.DTOs.Comment;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class CommentsService(IUsersService usersService,
                                 IMotorcyclesService motorcyclesService,
                                 ICommentsRepository commentsRepository) : ICommentsService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly ICommentsRepository _commentsRepository = commentsRepository;

        public async Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId,
                                                                                CommentQuery query)
        {
            return (await _commentsRepository.GetByMotorcycleIdAsync(motorcycleId,
                                                                        query)).Select(c => c.ToGetDTO());
        }

        public async Task<CommentGetDTO?> GetByIdAsync(Guid id)
        {
            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<CommentGetDTO?> CreateAsync(Guid motorcycleId,
                                                      CommentPostDTO dto)
        {
            await _motorcyclesService.GetByIdAsync(motorcycleId);

            var userId = _usersService.GetCurrentUserId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _commentsRepository.CreateAsync(dto.FromPostDTO(userId, motorcycleId));

            var model = await _commentsRepository.GetByIdAsync(id);

            return model.ToGetDTO();
        }

        public async Task<CommentGetDTO?> UpdateAsync(Guid id, CommentPutDTO dto)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(model);

            await _commentsRepository.UpdateAsync(model, update);

            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _commentsRepository.DeleteAsync(model);
        }
    }
}
