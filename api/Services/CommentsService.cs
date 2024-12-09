﻿using api.DTOs.Comment;
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

        public async Task<IEnumerable<CommentGetDTO>> GetAllByMotorcycleIdAsync(int motorcycleId,
                                                                                CommentQuery query)
        {
            return (await _commentsRepository.GetAllByMotorcycleIdAsync(motorcycleId,
                                                                        query)).Select(c => c.ToGetDTO());
        }

        public async Task<CommentGetDTO?> GetByIdAsync(int id)
        {
            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<CommentGetDTO?> CreateAsync(int motorcycleId,
                                                      CommentPostDTO dto)
        {
            await _motorcyclesService.GetByIdAsync(motorcycleId);

            var userId = _usersService.GetCurrentUserId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _commentsRepository.CreateAsync(dto.FromPostDTO(userId, motorcycleId));

            var model = await _commentsRepository.GetByIdAsync(id);

            return model.ToGetDTO();
        }

        public async Task<CommentGetDTO?> UpdateAsync(int id, CommentPutDTO dto)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(model);

            await _commentsRepository.UpdateAsync(model, update);

            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _commentsRepository.DeleteAsync(model);
        }
    }
}
