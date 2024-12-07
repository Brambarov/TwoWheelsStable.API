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
                              IRefreshTokensService refreshTokensService,
                              SignInManager<User> signInManager,
                              IConfiguration configuration,
                              IHttpContextAccessor httpContextAccessor) : IUsersService
    {
        private readonly IUsersRepository _usersRepository = usersRepository;
        private readonly IRefreshTokensService _refreshTokensService = refreshTokensService;
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
            var id = await _usersRepository.CreateAsync(dto.FromRegisterPostDTO(), dto.Password);

            var model = await _usersRepository.GetByIdAsync(id);

            var accessToken = GenerateAccessToken(model);
            var refreshToken = await _refreshTokensService.CreateAsync(model.Id, _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());

            return /*model.*/ UserMapper.ToLoginGetDTO(model.Id, accessToken, refreshToken.Token);
        }

        public async Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto)
        {
            var model = await _usersRepository.GetByUserNameAsync(dto.UserName);

            if (!(await _signInManager.CheckPasswordSignInAsync(model,
                                                                dto.Password,
                                                                false)).Succeeded) throw new ApplicationException(UserNameOrPasswordIncorrectError);

            var accessToken = GenerateAccessToken(model);
            var refreshToken = await _refreshTokensService.CreateAsync(model.Id, _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());

            return /*model.*/ UserMapper.ToLoginGetDTO(model.Id, accessToken, refreshToken.Token);
        }

        public async Task<UserGetDTO?> UpdateAsync(string id, UserPutDTO dto)
        {
            var model = await _usersRepository.GetByIdAsync(id);

            if (model.Id != GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(model);

            await _usersRepository.UpdateAsync(update);

            return (await _usersRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(string id)
        {
            var model = await _usersRepository.GetByIdAsync(id);

            if (model.Id != GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _usersRepository.DeleteAsync(model);
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
                   ?? throw new ApplicationException(string.Format(NotFoundError, "Id"));
        }

        public async Task<string[]> GetByRefreshTokenAsync(string refreshToken)
        {
            var model = await _usersRepository.GetByRefreshTokenAsync(refreshToken);

            var storedRefreshToken = model.RefreshTokens.FirstOrDefault(rt => rt.Token.Equals(refreshToken));
            if (storedRefreshToken == null || storedRefreshToken.IsRevoked || storedRefreshToken.IsUsed)
            {
                throw new ApplicationException("Invalid or expired refresh token!");
            }

            if (storedRefreshToken.Expires < DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Refresh token has expired!");
            }

            storedRefreshToken.IsUsed = true;

            var newAccessToken = GenerateAccessToken(model);
            var newRefreshToken = await _refreshTokensService.CreateAsync(model.Id, _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());

            await _usersRepository.UpdateAsync(model);

            return [newAccessToken, newRefreshToken.Token];
        }

        private string GenerateAccessToken(User user)
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
                Expires = DateTime.Now.AddMinutes(15),
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
