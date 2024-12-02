using api.DTOs.Image;
using api.Helpers.Mappers;
using api.Repositories.Contracts;
using api.Services.Contracts;

namespace api.Services
{
    public class ImagesService(IImagesRepository imagesRepository) : IImagesService
    {
        private readonly IImagesRepository _imagesRepository = imagesRepository;

        public async Task<IEnumerable<ImageGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId)
        {
            return (await _imagesRepository.GetByMotorcycleIdAsync(motorcycleId)).Select(i => i.ToGetDTO());
        }

        public async Task CreateAsync(IFormFile file, Guid motorcycleId)
        {
            await _imagesRepository.CreateAsync(await file.FromFormFile(motorcycleId));
        }

        public async Task BatchCreateAsync(List<IFormFile> files, Guid motorcycleId)
        {
            foreach (var file in files)
            {
                await _imagesRepository.CreateAsync(await file.FromFormFile(motorcycleId));
            }
        }

        public Task DeleteAsync(ImageGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
