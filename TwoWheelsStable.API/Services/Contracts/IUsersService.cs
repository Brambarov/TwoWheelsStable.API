using Microsoft.AspNetCore.Mvc;
using TwoWheelsStable.API.DTOs.User;
using TwoWheelsStable.API.Helpers.Queries;

namespace TwoWheelsStable.API.Services.Contracts
{
    public interface IUsersService
    {
        Task<IEnumerable<UserGetDTO>> GetAllAsync(UserQuery query, IUrlHelper urlHelper);
        Task<UserGetDTO?> GetByIdAsync(string id, IUrlHelper urlHelper);
        Task<UserGetDTO?> GetByUserNameAsync(string userName, IUrlHelper urlHelper);
        Task<string[]> GetByRefreshTokenAsync(string refreshToken);
        Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto, IUrlHelper urlHelper);
        Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto, IUrlHelper urlHelper);
        Task<UserGetDTO?> UpdateAsync(string id, UserPutDTO dto, IUrlHelper urlHelper);
        Task DeleteAsync(string id);
        string GetCurrentUserId();
    }
}
