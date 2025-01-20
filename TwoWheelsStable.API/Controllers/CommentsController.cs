using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TwoWheelsStable.API.DTOs.Comment;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentsService commentsService,
                                    IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly ICommentsService _commentsService = commentsService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

        [HttpGet("{id:guid}", Name = "GetCommentById")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _commentsService.GetByIdAsync(id, urlHelper));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
                                                [FromBody] CommentPutDTO putDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            return Ok(await _commentsService.UpdateAsync(id, putDto, urlHelper));
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
