using api.DTOs.User;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.GetAllAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.GetByIdAsync(id));
        }

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

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] string id,
                                                [FromBody] UserPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.DeleteAsync(id));
        }
    }
}
