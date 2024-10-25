using api.DTOs.Motorcycle;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {
        private readonly IMotorcyclesService _motorcyclesService;

        public MotorcyclesController(IMotorcyclesService motorcyclesService)
        {
            _motorcyclesService = motorcyclesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getDtos = await _motorcyclesService.GetAllAsync();

            return Ok(getDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var getDto = await _motorcyclesService.GetByIdAsync(id);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotorcyclePostDTO postDto)
        {
            var getDto = await _motorcyclesService.CreateAsync(postDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] MotorcyclePutDTO putDto)
        {
            var getDto = await _motorcyclesService.UpdateAsync(id, putDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var getDto = await _motorcyclesService.DeleteAsync(id);

            return getDto == null ? NotFound() : NoContent();
        }
    }
}
