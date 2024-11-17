using api.DTOs.User;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

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
        public async Task<IActionResult> Login([FromBody] UserLoginPostDTO dto)
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

        // TODO: Create an endpoint to get user by Id and view his stable
        [HttpGet]
        public async Task<IActionResult> GetByUserName([FromQuery] string userName)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _usersService.GetByUserNameAsync(userName);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        // TODO: Implement soft delete for all entity types
    }
}
