using api.DTOs.Job;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController(IJobsService jobsService,
                                IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly IJobsService _jobsService = jobsService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

        [HttpGet("{id:guid}", Name = "GetJobById")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _jobsService.GetByIdAsync(id, urlHelper));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] JobPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _jobsService.UpdateAsync(id, putDto, urlHelper));
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _jobsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
