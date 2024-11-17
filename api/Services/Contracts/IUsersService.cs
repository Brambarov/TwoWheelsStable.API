using api.DTOs.User;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IUsersService
    {
        Task<IEnumerable<UserGetDTO>> GetAllAsync(UserQuery query);
        Task<UserGetDTO?> GetByIdAsync(string id);
        Task<UserGetDTO?> GetByUserNameAsync(string userName);
        Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto);
        Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto);
        Task<UserGetDTO?> UpdateAsync(string id, UserPutDTO dto);
        Task<UserGetDTO?> DeleteAsync(string id);
        string? GetId();
    }
}
