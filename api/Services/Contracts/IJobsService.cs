using api.DTOs.Job;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IJobsService
    {
        Task<IEnumerable<JobGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId, JobQuery query);
        Task<JobGetDTO?> GetByIdAsync(Guid id);
        Task<JobGetDTO?> CreateAsync(Guid motorcycleId, JobPostDTO dto);
        Task<JobGetDTO?> UpdateAsync(Guid id, JobPutDTO dto);
        Task DeleteAsync(Guid id);
    }
}
