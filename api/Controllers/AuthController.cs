using api.DTOs.User;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterPostDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.RegisterAsync(dto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginPostDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.LoginAsync(dto));
        }
    }
}
