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
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? throw new ApplicationException("JWT Signing key exception!")));
        }

        // TODO: Introduce repository layer for User model
        public async Task<UserLoginGetDTO> RegisterAsync(UserRegisterPostDTO dto)
        {
            var model = dto.FromRegisterPostDTO();

            var createdUser = await _userManager.CreateAsync(model, dto.Password);

            if (!createdUser.Succeeded)
            {
                var error = createdUser.Errors.FirstOrDefault() ?? throw new ApplicationException("Registration exception!");

                throw new ApplicationException(error.Description);
            }

            var roleResult = await _userManager.AddToRoleAsync(model, "User");

            if (!roleResult.Succeeded)
            {
                var error = roleResult.Errors.FirstOrDefault() ?? throw new ApplicationException("Registration exception!");

                throw new ApplicationException(error.Description ?? "Registration exception!");
            }

            var token = CreateToken(model);

            return model.ToLoginGetDTO(token);
        }

        public async Task<UserLoginGetDTO> LoginAsync(UserLoginPostDTO dto)
        {
            var model = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName != null && u.UserName.Equals(dto.UserName.ToLower())) ?? throw new ApplicationException("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(model, dto.Password, false);

            if (!result.Succeeded) throw new ApplicationException("Username/password is incorrect!");

            var token = CreateToken(model);

            return model.ToLoginGetDTO(token);
        }

        public async Task<UserGetDTO?> GetByIdAsync(string id)
        {
            var model = await _userManager.Users.Include(u => u.Stable)
                                                .ThenInclude(m => m.Specs)
                                                .FirstOrDefaultAsync(u => u.Id.Equals(id)) ?? throw new ApplicationException("User does not exist!");

            if (model == null) return null;

            return model.ToGetDTO();
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
