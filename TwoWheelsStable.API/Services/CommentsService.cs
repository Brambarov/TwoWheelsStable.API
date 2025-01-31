﻿using Microsoft.AspNetCore.Mvc;
using TwoWheelsStable.API.DTOs.Comment;
using TwoWheelsStable.API.Helpers.Mappers;
using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Repositories.Contracts;
using TwoWheelsStable.API.Services.Contracts;
using static TwoWheelsStable.API.Helpers.Constants.ErrorMessages;

namespace TwoWheelsStable.API.Services
{
    public class CommentsService(IUsersService usersService,
                                 IMotorcyclesService motorcyclesService,
                                 ICommentsRepository commentsRepository) : ICommentsService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly ICommentsRepository _commentsRepository = commentsRepository;

        public async Task<IEnumerable<CommentGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId,
                                                                             CommentQuery query,
                                                                             IUrlHelper urlHelper)
        {
            return (await _commentsRepository.GetByMotorcycleIdAsync(motorcycleId,
                                                                        query)).Select(c => c.ToGetDTO(urlHelper));
        }

        public async Task<CommentGetDTO?> GetByIdAsync(Guid id, IUrlHelper urlHelper)
        {
            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO(urlHelper);
        }

        public async Task<CommentGetDTO?> CreateAsync(Guid motorcycleId,
                                                      CommentPostDTO dto,
                                                      IUrlHelper urlHelper)
        {
            await _motorcyclesService.GetByIdAsync(motorcycleId, urlHelper);

            var userId = _usersService.GetCurrentUserId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _commentsRepository.CreateAsync(dto.FromPostDTO(userId, motorcycleId));

            var model = await _commentsRepository.GetByIdAsync(id);

            return model.ToGetDTO(urlHelper);
        }

        public async Task<CommentGetDTO?> UpdateAsync(Guid id,
                                                      CommentPutDTO dto,
                                                      IUrlHelper urlHelper)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(model);

            await _commentsRepository.UpdateAsync(model, update);

            return (await _commentsRepository.GetByIdAsync(id)).ToGetDTO(urlHelper);
        }

        public async Task DeleteAsync(Guid id)
        {
            var model = await _commentsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _commentsRepository.DeleteAsync(model);
        }
    }
}
