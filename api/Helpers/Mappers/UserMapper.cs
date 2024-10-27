using api.DTOs.User;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class UserMapper
    {
        public static UserGetDTO ToGetDTO(this User model, string token)
        {
            return new UserGetDTO
            {
                UserName = model.UserName,
                Email = model.Email,
                Token = token
            };
        }

        public static User FromRegisterPostDTO(this UserRegisterPostDTO dto)
        {
            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email
            };
        }
    }
}
