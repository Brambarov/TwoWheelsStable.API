using api.DTOs.Image;
using api.Helpers.Mappers;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class ImagesService(IImagesRepository imagesRepository) : IImagesService
    {
        private readonly IImagesRepository _imagesRepository = imagesRepository;

        public async Task<IEnumerable<ImageGetDTO>> GetByMotorcycleIdAsync(int motorcycleId)
        {
            return (await _imagesRepository.GetByMotorcycleIdAsync(motorcycleId)).Select(i => i.ToGetDTO());
        }

        public async Task<int?> CreateAsync(ImagePostDTO dto, int motorcycleId)
        {
            return await _imagesRepository.CreateAsync(dto.FromPostDTO(motorcycleId));
        }

        public Task DeleteAsync(ImageGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
