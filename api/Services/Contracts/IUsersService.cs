using api.Models;

namespace api.Services.Contracts
{
    public interface IUsersService
    {
        string CreateToken(User user);
    }
}
