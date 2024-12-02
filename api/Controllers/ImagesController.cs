using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IImagesService imagesService) : ControllerBase
    {
        private readonly IImagesService _imagesService = imagesService;

        [HttpPost("{motorcycleId:guid}")]
        public async Task<IActionResult> BatchCreate([FromRoute] Guid motorcycleId, [FromForm] List<IFormFile> files)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _imagesService.BatchCreateAsync(files, motorcycleId);

            return Ok();
        }
    }
}
