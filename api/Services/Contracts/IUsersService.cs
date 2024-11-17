using api.DTOs.User;

namespace api.Services.Contracts
{
    public interface IUsersService
    {
        Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto);
        Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto);
        Task<UserGetDTO?> GetByIdAsync(string id);
        Task<UserGetDTO?> GetByUserNameAsync(string userName);
        string? GetId();
    }
}
