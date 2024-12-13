using api.DTOs.Comment;
using api.DTOs.Job;
using api.DTOs.Motorcycle;
using api.Helpers.Queries;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController(IMotorcyclesService motorcyclesService,
                                       ICommentsService commentsService,
                                       IJobsService jobsService,
                                       IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly ICommentsService _commentsService = commentsService;
        private readonly IJobsService _jobsService = jobsService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MotorcycleQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _motorcyclesService.GetAllAsync(query, urlHelper));
        }

        [HttpGet("{id:guid}", Name = "GetMotorcycleById")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _motorcyclesService.GetByIdAsync(id, urlHelper));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotorcyclePostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _motorcyclesService.CreateAsync(postDto, urlHelper));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] MotorcyclePutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _motorcyclesService.UpdateAsync(id, putDto, urlHelper));
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _motorcyclesService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("{id:guid}/comments")]
        public async Task<IActionResult> GetCommentsByMotorcycleId([FromRoute] Guid id,
                                                                   [FromQuery] CommentQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _commentsService.GetByMotorcycleIdAsync(id, query, urlHelper));
        }

        [Authorize]
        [HttpPost("{id:guid}/comments")]
        public async Task<IActionResult> CreateComment([FromRoute] Guid id,
                                                       [FromBody] CommentPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _commentsService.CreateAsync(id, postDto, urlHelper));
        }

        [HttpGet("{id:guid}/jobs")]
        public async Task<IActionResult> GetJobsByMotorcycleId([FromRoute] Guid id,
                                                               [FromQuery] JobQuery query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _jobsService.GetByMotorcycleIdAsync(id, query, urlHelper));
        }

        [Authorize]
        [HttpPost("{id:guid}/jobs")]
        public async Task<IActionResult> CreateJob([FromRoute] Guid id,
                                                   [FromBody] JobPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _jobsService.CreateAsync(id, postDto, urlHelper));
        }
    }
}
