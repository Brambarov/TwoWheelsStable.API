using api.DTOs.Comment;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Helpers.Mappers
{
    public static class CommentMapper
    {
        public static CommentGetDTO ToGetDTO(this Comment model, IUrlHelper urlHelper)
        {
            return new CommentGetDTO
            {
                Href = urlHelper.Link("GetCommentById", new { id = model.Id })
                       ?? throw new ArgumentNullException(nameof(urlHelper), "Resource address is null!"),
                Title = model.Title,
                Content = model.Content,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.User?.UserName
            };
        }

        public static Comment FromPostDTO(this CommentPostDTO dto, string userId, Guid motorcycleId)
        {
            return new Comment
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = userId,
                MotorcycleId = motorcycleId,
                CreatedOn = DateTime.Now
            };
        }

        public static Comment FromPutDTO(this CommentPutDTO dto, Comment model)
        {
            model.Title = dto.Title;
            model.Content = dto.Content;

            return model;
        }
    }
}
