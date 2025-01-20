using Microsoft.AspNetCore.Mvc;
using TwoWheelsStable.API.DTOs.Job;
using TwoWheelsStable.API.Helpers.Queries;

namespace TwoWheelsStable.API.Services.Contracts
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
