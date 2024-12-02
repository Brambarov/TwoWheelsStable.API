using api.DTOs.Comment;
using api.DTOs.Job;
using api.DTOs.Motorcycle;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController(IMotorcyclesService motorcyclesService,
                                       ICommentsService commentsService,
                                       IJobsService jobsService) : ControllerBase
    {
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly ICommentsService _commentsService = commentsService;
        private readonly IJobsService _jobsService = jobsService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MotorcycleQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _motorcyclesService.GetAllAsync(query));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _motorcyclesService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MotorcyclePostDTO postDto, [FromForm] List<IFormFile> files)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _motorcyclesService.CreateAsync(postDto, files));
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] MotorcyclePutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _motorcyclesService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _motorcyclesService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetCommentsByMotorcycleId([FromRoute] Guid id,
                                                                   [FromQuery] CommentQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.GetByMotorcycleIdAsync(id, query));
        }

        [Authorize]
        [HttpPost("{id:int}/comments")]
        public async Task<IActionResult> CreateComment([FromRoute] Guid id,
                                                       [FromBody] CommentPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.CreateAsync(id, postDto));
        }

        [HttpGet("{id:int}/jobs")]
        public async Task<IActionResult> GetJobsByMotorcycleId([FromRoute] Guid id,
                                                               [FromQuery] JobQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.GetByMotorcycleIdAsync(id, query));
        }

        [Authorize]
        [HttpPost("{id:int}/jobs")]
        public async Task<IActionResult> CreateJob([FromRoute] Guid id,
                                                   [FromBody] JobPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _jobsService.CreateAsync(id, postDto));
        }
    }
}
