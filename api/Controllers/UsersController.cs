using api.DTOs.User;
using api.Models;
using api.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUsersService _usersService;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, IUsersService usersService, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _usersService = usersService;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterPostDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email
                };

                var createdUser = await _userManager.CreateAsync(user, dto.Password);

                if (!createdUser.Succeeded) return StatusCode(500, createdUser.Errors);

                var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (!roleResult.Succeeded) return StatusCode(500, roleResult.Errors);

                return Ok(
                    new UserGetDTO
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _usersService.CreateToken(user)
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginPostDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.Equals(dto.UserName.ToLower()));

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username/password is incorrect!");

            return Ok(
                    new UserGetDTO
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _usersService.CreateToken(user)
                    }
                );
        }
    }
}
