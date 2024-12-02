using api.DTOs.Image;

namespace api.Services.Contracts
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageGetDTO>> GetByMotorcycleIdAsync(int motorcycleId);
        Task<int?> CreateAsync(ImagePostDTO dto, int motorcycleId);
        Task DeleteAsync(ImageGetDTO dto);
    }
}
