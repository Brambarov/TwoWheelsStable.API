using api.DTOs.User;

namespace api.Services.Contracts
{
    public interface IUsersService
    {
        Task<UserGetDTO> RegisterAsync(UserRegisterPostDTO dto);
        Task<UserGetDTO> LoginAsync(UserLoginPostDTO dto);
    }
}
