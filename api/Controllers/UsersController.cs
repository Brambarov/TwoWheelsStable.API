using api.DTOs.User;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterPostDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                return Ok(await _usersService.RegisterAsync(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginPostDTO dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                return Ok(await _usersService.LoginAsync(dto));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
