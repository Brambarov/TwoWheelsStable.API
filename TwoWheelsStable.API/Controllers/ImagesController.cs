using Microsoft.AspNetCore.Mvc;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IImagesService imagesService) : ControllerBase
    {
        private readonly IImagesService _imagesService = imagesService;

        [HttpPost("{resourceId:guid}")]
        public async Task<IActionResult> BatchCreate([FromRoute] Guid resourceId, [FromForm] List<IFormFile> files)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _imagesService.BatchCreateAsync(files, resourceId);

            return Ok();
        }

        [HttpGet("{resourceId:guid}")]
        public async Task<IActionResult> GetByResourceId([FromRoute] Guid resourceId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var test = await _imagesService.GetByResourceIdAsync(resourceId);

            return Ok(test);
        }
    }
}
