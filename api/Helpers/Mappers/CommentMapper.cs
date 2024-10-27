using api.DTOs.Comment;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class CommentMapper
    {
        public static CommentGetDTO ToGetDTO(this Comment model)
        {
            return new CommentGetDTO
            {
                Title = model.Title,
                Content = model.Content,
                MotorcycleId = model.MotorcycleId,
                CreatedOn = model.CreatedOn,
                CreatedBy = model.User?.UserName
            };
        }

        public static Comment FromPostDTO(this CommentPostDTO dto, string userId, int motorcycleId)
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

        public static Comment FromPutDTO(this Comment model, int id, int? motorcycleId, CommentPutDTO dto)
        {
            model.Id = id;
            model.Title = dto.Title;
            model.Content = dto.Content;
            model.MotorcycleId = motorcycleId;

            return model;
        }
    }
}
