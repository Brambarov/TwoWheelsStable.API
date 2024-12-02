using api.Models;

namespace api.Repositories.Contracts
{
    public interface IImagesRepository
    {
        Task<IEnumerable<Image>> GetByMotorcycleIdAsync(int motorcycleId);
        Task<int?> CreateAsync(Image model);
        Task DeleteAsync(Image model);
    }
}
