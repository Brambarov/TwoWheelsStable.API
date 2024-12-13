using api.DTOs.Job;
using api.Helpers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace api.Services.Contracts
{
    public interface IJobsService
    {
        Task<IEnumerable<JobGetDTO>> GetByMotorcycleIdAsync(Guid motorcycleId, JobQuery query, IUrlHelper urlHelper);
        Task<JobGetDTO?> GetByIdAsync(Guid id, IUrlHelper urlHelper);
        Task<JobGetDTO?> CreateAsync(Guid motorcycleId, JobPostDTO dto, IUrlHelper urlHelper);
        Task<JobGetDTO?> UpdateAsync(Guid id, JobPutDTO dto, IUrlHelper urlHelper);
        Task DeleteAsync(Guid id);
    }
}
