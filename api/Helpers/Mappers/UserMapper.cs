using api.DTOs.User;
using api.Models;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Helpers.Mappers
{
    public static class UserMapper
    {
        public static UserGetDTO ToGetDTO(this User model)
        {
            var userName = model.UserName ?? throw new ApplicationException(string.Format(GenericExceptionError, "UserName"));

            return new UserGetDTO
            {
                UserName = userName,
                Stable = model.Stable.Select(m => m.ToGetDTO()).ToList()
            };
        }

        public static UserLoginGetDTO ToLoginGetDTO(this User model, string token)
        {
            var userName = model.UserName ?? throw new ApplicationException(string.Format(GenericExceptionError, "UserName"));
            var email = model.Email ?? throw new ApplicationException(string.Format(GenericExceptionError, "Email"));

            return new UserLoginGetDTO
            {
                UserName = userName,
                Email = email,
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

        public static User FromPutDTO(this UserPutDTO dto, string id)
        {
            return new User
            {
                Id = id,
                UserName = dto.UserName,
            };
        }
    }
}
