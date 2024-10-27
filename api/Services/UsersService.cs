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
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
        }

        public async Task<UserGetDTO> RegisterAsync(UserRegisterPostDTO dto)
        {
            var user = dto.FromRegisterPostDTO();

            var createdUser = await _userManager.CreateAsync(user, dto.Password);

            if (!createdUser.Succeeded) throw new ApplicationException(createdUser.Errors.FirstOrDefault().Description);

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!createdUser.Succeeded) throw new ApplicationException(roleResult.Errors.FirstOrDefault().Description);

            var token = CreateToken(user);

            return user.ToGetDTO(token);
        }

        public async Task<UserGetDTO> LoginAsync(UserLoginPostDTO dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.Equals(dto.UserName.ToLower()));

            if (user == null) throw new ApplicationException("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded) throw new ApplicationException("Username/password is incorrect!");

            var token = CreateToken(user);

            return user.ToGetDTO(token);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
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
