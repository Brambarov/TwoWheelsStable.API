using api.DTOs.User;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService,
                                 IMotorcyclesService motorcyclesService,
                                 IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _usersService.GetAllAsync(query, urlHelper));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _usersService.GetByIdAsync(id, urlHelper));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id,
                                                [FromBody] UserPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _usersService.UpdateAsync(id, putDto, urlHelper));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _usersService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id}/motorcycles")]
        public async Task<IActionResult> GetMotorcyclesByUserId([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _motorcyclesService.GetByUserIdAsync(id, urlHelper));
        }
    }
}
