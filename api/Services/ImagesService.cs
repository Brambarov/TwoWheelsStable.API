using api.DTOs.Image;
using api.Helpers.Mappers;
using api.Repositories.Contracts;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace api.Services
{
    public class ImagesService(IImagesRepository imagesRepository) : IImagesService
    {
        private readonly IImagesRepository _imagesRepository = imagesRepository;

        public async Task<IEnumerable<ImageGetDTO>> GetByResourceIdAsync(Guid resourceId, IUrlHelper urlHelper)
        {
            return (await _imagesRepository.GetByResourceIdAsync(resourceId)).Select(i => i.ToGetDTO(urlHelper));
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
