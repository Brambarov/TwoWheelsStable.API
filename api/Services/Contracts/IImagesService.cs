using api.DTOs.Image;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface IImagesService
    {
        Task<IEnumerable<ImageGetDTO>> GetByResourceIdAsync(Guid resourceId, IUrlHelper urlHelper);
        Task CreateAsync(IFormFile file, Guid resourceId);
        Task BatchCreateAsync(List<IFormFile> files, Guid resourceId);
        Task DeleteAsync(ImageGetDTO dto);
    }
}
