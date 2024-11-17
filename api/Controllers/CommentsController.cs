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

            return Ok(await _commentsService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("{motorcycleId:int}")]
        public async Task<IActionResult> Create([FromRoute] int motorcycleId,
                                                [FromBody] CommentPostDTO postDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.CreateAsync(motorcycleId, postDto));
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] CommentPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.DeleteAsync(id));
        }
    }
}
