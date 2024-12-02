using api.DTOs.Job;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IJobsService jobsService) : ControllerBase
    {
        private readonly IJobsService _jobsService = jobsService;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] JobPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _jobsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
