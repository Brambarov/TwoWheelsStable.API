using api.DTOs.User;
using api.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface IUsersService
    {
        Task<IEnumerable<UserGetDTO>> GetAllAsync(UserQuery query, IUrlHelper urlHelper);
        Task<UserGetDTO?> GetByIdAsync(string id, IUrlHelper urlHelper);
        Task<UserGetDTO?> GetByUserNameAsync(string userName, IUrlHelper urlHelper);
        Task<string[]> GetByRefreshTokenAsync(string refreshToken);
        Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto);
        Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto);
        Task<UserGetDTO?> UpdateAsync(string id, UserPutDTO dto, IUrlHelper urlHelper);
        Task DeleteAsync(string id);
        string GetCurrentUserId();
    }
}
