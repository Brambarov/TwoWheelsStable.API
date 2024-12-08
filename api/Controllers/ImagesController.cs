using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IImagesService imagesService,
                                  IUrlHelperFactory urlHelperFactory) : ControllerBase
    {
        private readonly IImagesService _imagesService = imagesService;
        private readonly IUrlHelperFactory _urlHelperFactory = urlHelperFactory;

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

            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);

            var test = await _imagesService.GetByResourceIdAsync(resourceId, urlHelper);

            return Ok(test);
        }
    }
}
