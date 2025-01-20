using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Repositories.Contracts
{
    public interface IImagesRepository
    {
        Task<IEnumerable<Image>> GetByResourceIdAsync(Guid motorcycleId);
        Task<Guid> CreateAsync(Image model);
        Task DeleteAsync(Image model);
    }
}
