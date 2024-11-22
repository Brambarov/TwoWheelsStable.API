using api.DTOs.Job;
using api.Helpers.Queries;

namespace api.Services.Contracts
{
    public interface IJobsService
    {
        Task<IEnumerable<JobGetDTO>> GetAllByMotorcycleIdAsync(int motorcycleId, JobQuery query);
        Task<JobGetDTO?> GetByIdAsync(int id);
        Task<JobGetDTO?> CreateAsync(int motorcycleId, JobPostDTO dto);
        Task<JobGetDTO?> UpdateAsync(int id, JobPutDTO dto);
        Task<JobGetDTO?> DeleteAsync(int id);
    }
}
