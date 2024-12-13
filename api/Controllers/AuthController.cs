using api.DTOs.User;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUsersService usersService,
                                IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterPostDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _usersService.RegisterAsync(dto, urlHelper));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginPostDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _usersService.LoginAsync(dto, urlHelper));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _usersService.GetByRefreshTokenAsync(refreshToken));
        }
    }
}
