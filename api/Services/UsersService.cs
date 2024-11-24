using api.DTOs.User;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class UsersService(IUsersRepository usersRepository,
                        SignInManager<User> signInManager,
                        IConfiguration configuration,
                        IHttpContextAccessor httpContextAccessor) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly IConfiguration _configuration = configuration;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? throw new ApplicationException(JWTSigningKeyError)));

        public async Task<IEnumerable<UserGetDTO>> GetAllAsync(UserQuery query)
        {
            return (await _usersRepository.GetAllAsync(query)).Select(u => u.ToGetDTO());
        }

        public async Task<UserGetDTO?> GetByIdAsync(string id)
        {
            return (await _usersRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<UserGetDTO?> GetByUserNameAsync(string userName)
        {
            return (await _usersRepository.GetByUserNameAsync(userName)).ToGetDTO();
        }

        public async Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto)
        {
            var model = await _usersRepository.GetByIdAsync(await _usersRepository.CreateAsync(dto.FromRegisterPostDTO(),
                                                                                               dto.Password));

            var token = CreateToken(model);

            return model.ToLoginGetDTO(token);
        }

        public async Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto)
        {
            var model = await _usersRepository.GetByUserNameAsync(dto.UserName);

            if (!(await _signInManager.CheckPasswordSignInAsync(model,
                                                                dto.Password,
                                                                false)).Succeeded) throw new ApplicationException(UserNameOrPasswordIncorrectError);

            var token = CreateToken(model);

            return model.ToLoginGetDTO(token);
        }

        public async Task<UserGetDTO?> UpdateAsync(string id, UserPutDTO dto)
        {
            var model = await _usersRepository.GetByIdAsync(id);

            if (model.Id != GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(id);

            await _usersRepository.UpdateAsync(model, update);

            model = await _usersRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<UserGetDTO?> DeleteAsync(string id)
        {
            var model = await _usersRepository.GetByIdAsync(id);

            if (model.Id != GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _usersRepository.DeleteAsync(model);

            return model.ToGetDTO();
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
                   ?? throw new ApplicationException(string.Format(NotFoundError, "Id"));
        }

        private string CreateToken(User user)
        {
            var userName = user.UserName
                           ?? throw new ApplicationException(string.Format(TokenCreationError, "UserName"));
            var email = user.Email
                        ?? throw new ApplicationException(string.Format(TokenCreationError, "Email"));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(JwtRegisteredClaimNames.GivenName, userName),
                new(JwtRegisteredClaimNames.Email, email)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
