using api.DTOs.Comment;
using api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentsService commentsService) : ControllerBase
    {
        private readonly ICommentsService _commentsService = commentsService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDtos = await _commentsService.GetAllAsync();

            return Ok(getDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _commentsService.GetByIdAsync(id);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [Authorize]
        [HttpPost("{motorcycleId:int}")]
        public async Task<IActionResult> Create([FromRoute] int motorcycleId,
                                                [FromBody] CommentPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _commentsService.CreateAsync(motorcycleId, postDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] CommentPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _commentsService.UpdateAsync(id, putDto);

            return getDto == null ? NotFound() : Ok(getDto);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getDto = await _commentsService.DeleteAsync(id);

            return getDto == null ? NotFound() : NoContent();
        }
    }
}
