using TwoWheelsStable.API.DTOs.Image;
using TwoWheelsStable.API.Helpers.Mappers;
using TwoWheelsStable.API.Repositories.Contracts;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.API.Services
{
    public class ImagesService(IImagesRepository imagesRepository) : IImagesService
    {
        private readonly IImagesRepository _imagesRepository = imagesRepository;

        public async Task<IEnumerable<ImageGetDTO>> GetByResourceIdAsync(Guid resourceId)
        {
            return (await _imagesRepository.GetByResourceIdAsync(resourceId)).Select(i => i.ToGetDTO());
        }

        public async Task CreateAsync(IFormFile file, Guid resourceId)
        {
            await _imagesRepository.CreateAsync(await file.FromFormFile(resourceId));
        }

        public async Task BatchCreateAsync(List<IFormFile> files, Guid resourceId)
        {
            foreach (var file in files)
            {
                await _imagesRepository.CreateAsync(await file.FromFormFile(resourceId));
            }
        }

        public Task DeleteAsync(ImageGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
