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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] CommentPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _commentsService.UpdateAsync(id, putDto));
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _commentsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
