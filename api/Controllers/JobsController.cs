using api.DTOs.Job;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/motorcycles/{motorcycleId}/[controller]")]
    [ApiController]
    public class JobsController(IJobsService jobsService) : ControllerBase
    {
        private readonly IJobsService _jobsService = jobsService;

        [HttpGet]
        public async Task<IActionResult> GetAllByMotorcycleId([FromRoute] int motorcycleId,
                                                              [FromQuery] JobQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.GetAllByMotorcycleIdAsync(motorcycleId, query));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("{motorcycleId:int}")]
        public async Task<IActionResult> Create([FromRoute] int motorcycleId,
                                                [FromBody] JobPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.CreateAsync(motorcycleId, postDto));
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] JobPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.DeleteAsync(id));
        }
    }
}
