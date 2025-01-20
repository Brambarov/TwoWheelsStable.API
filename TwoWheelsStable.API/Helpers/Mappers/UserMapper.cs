using api.DTOs.User;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Helpers.Mappers
{
    public static class UserMapper
    {
        public static UserGetDTO ToGetDTO(this User model, IUrlHelper urlHelper)
        {
            var userName = model.UserName ?? throw new ApplicationException(string.Format(GenericExceptionError, "UserName"));

            return new UserGetDTO
            {
                Href = urlHelper.Link("GetUserById", new { id = model.Id })
                       ?? throw new ArgumentNullException(nameof(urlHelper), "Resource address is null!"),
                UserName = userName,
                Motorcycles = model.Motorcycles.Select(m => m.ToGetDTO(urlHelper)).ToList()
            };
        }

        public static UserLoginGetDTO ToLoginGetDTO(string userId, string accessToken, string refreshToken, IUrlHelper urlHelper)
        {
            return new UserLoginGetDTO
            {
                Href = urlHelper.Link("GetUserById", new { id = userId })
                       ?? throw new ArgumentNullException(nameof(urlHelper), "Resource address is null!"),
                AccessToken = accessToken,
                RefreshToken = refreshToken
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

        public static User FromPutDTO(this UserPutDTO dto, User model)
        {
            model.UserName = dto.UserName;

            return model;
        }
    }
}
