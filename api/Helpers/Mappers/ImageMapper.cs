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
                Id = model.Id,
                Data = model.Data,
                FileName = model.FileName,
                MimeType = model.MimeType
            };
        }
        public static Image FromPostDTO(this ImagePostDTO dto, int? motorcycleId)
        {
            return new Image
            {
                MotorcycleId = motorcycleId,
                Data = dto.Data,
                FileName = dto.FileName,
                MimeType = dto.MimeType
            };
        }
    }
}
