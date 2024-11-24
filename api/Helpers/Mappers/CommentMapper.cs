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

        public static Comment FromPutDTO(this CommentPutDTO dto, int id, int? motorcycleId)
        {
            return new Comment
            {
                Id = id,
                Title = dto.Title,
                Content = dto.Content,
                MotorcycleId = motorcycleId

            };
        }
    }
}
