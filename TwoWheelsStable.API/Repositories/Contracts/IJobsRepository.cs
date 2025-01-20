using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Repositories.Contracts
{
    public interface IJobsRepository
    {
        Task<IEnumerable<Job>> GetByMotorcycleIdAsync(Guid motorcycleId, JobQuery query);
        Task<Job> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Job model);
        Task UpdateAsync(Job model, Job update);
        Task DeleteAsync(Job model);
        Task<bool> Exists(Guid id);
    }
}
