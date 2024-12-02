using api.DTOs.Image;

namespace api.Services.Contracts
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId);
        Task<Guid> CreateAsync(IFormFile file, Guid motorcycleId);
        Task DeleteAsync(ImageGetDTO dto);
    }
}
