using api.DTOs.Image;

namespace api.Services.Contracts
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageGetDTO>> GetByResourceIdAsync(Guid resourceId);
        Task CreateAsync(IFormFile file, Guid resourceId);
        Task BatchCreateAsync(List<IFormFile> files, Guid resourceId);
        Task DeleteAsync(ImageGetDTO dto);
    }
}
