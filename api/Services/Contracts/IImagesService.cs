using api.DTOs.Image;

namespace api.Services.Contracts
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId);
        Task CreateAsync(IFormFile file, Guid motorcycleId);
        Task BatchCreateAsync(List<IFormFile> files, Guid motorcycleId);
        Task DeleteAsync(ImageGetDTO dto);
    }
}
