using api.DTOs.Image;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class ImageMapper
    {
        public static ImageGetDTO ToGetDTO(this Image model)
        {
            return new ImageGetDTO
            {
                Data = model.Data,
                FileName = model.FileName,
                MimeType = model.MimeType
            };
        }
        public static async Task<Image> FromFormFile(this IFormFile file, Guid resourceId)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            return new Image
            {
                ResourceId = resourceId,
                Data = memoryStream.ToArray(),
                FileName = file.FileName,
                MimeType = file.ContentType
            };
        }
    }
}
