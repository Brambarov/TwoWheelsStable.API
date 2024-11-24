using api.Helpers.Queries;
using api.Models;

namespace api.Repositories.Contracts
{
    public interface IJobsRepository
    {
        Task<IEnumerable<Job>> GetAllByMotorcycleIdAsync(int motorcycleId, JobQuery query);
        Task<Job> GetByIdAsync(int? id);
        Task<int?> CreateAsync(Job model);
        Task UpdateAsync(Job model, Job update);
        Task DeleteAsync(Job model);
        Task<bool> Exists(int id);
    }
}
