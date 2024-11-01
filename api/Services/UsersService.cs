using api.DTOs.User;
using api.Helpers.Mappers;
using api.Models;
using api.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public UsersService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"] ?? throw new ApplicationException("JWT Signing key exception!")));
        }

        public async Task<UserGetDTO> RegisterAsync(UserRegisterPostDTO dto)
        {
            var user = dto.FromRegisterPostDTO();

            var createdUser = await _userManager.CreateAsync(user, dto.Password);

            if (!createdUser.Succeeded)
            {
                var error = createdUser.Errors.FirstOrDefault() ?? throw new ApplicationException("Registration exception!");

                throw new ApplicationException(error.Description);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                var error = roleResult.Errors.FirstOrDefault() ?? throw new ApplicationException("Registration exception!");

                throw new ApplicationException(error.Description ?? "Registration exception!");
            }

            var token = CreateToken(user);

            return user.ToGetDTO(token);
        }

        public async Task<UserGetDTO> LoginAsync(UserLoginPostDTO dto)
        {
            var dtoUserName = dto.UserName ?? throw new ApplicationException("Username exception!");

            var dtoPassword = dto.Password ?? throw new ApplicationException("Password exception!");

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName != null && u.UserName.Equals(dtoUserName.ToLower())) ?? throw new ApplicationException("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dtoPassword, false);

            if (!result.Succeeded) throw new ApplicationException("Username/password is incorrect!");

            var token = CreateToken(user);

            return user.ToGetDTO(token);
        }

        private string CreateToken(User user)
        {
            var userName = user.UserName ?? throw new ApplicationException("UserName exception!");
            var email = user.Email ?? throw new ApplicationException("Email exception!");

            var claims = new List<Claim>
            {
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
