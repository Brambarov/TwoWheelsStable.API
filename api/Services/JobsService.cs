using api.DTOs.Job;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class JobsService(IUsersService usersService,
                             IMotorcyclesService motorcyclesService,
                             IJobsRepository jobsRepository) : IJobsService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IMotorcyclesService _motorcyclesService = motorcyclesService;
        private readonly IJobsRepository _jobsRepository = jobsRepository;

        public async Task<IEnumerable<JobGetDTO>> GetAllByMotorcycleIdAsync(int motorcycleId,
                                                                            JobQuery query)
        {
            return (await _jobsRepository.GetAllByMotorcycleIdAsync(motorcycleId,
                                                                    query)).Select(j => j.ToGetDTO());
        }

        public async Task<JobGetDTO?> GetByIdAsync(int id)
        {
            return (await _jobsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<JobGetDTO?> CreateAsync(int motorcycleId,
                                                  JobPostDTO dto)
        {
            await _motorcyclesService.GetByIdAsync(motorcycleId);

            var id = await _jobsRepository.CreateAsync(dto.FromPostDTO(_usersService.GetCurrentUserId(),
                                                                       motorcycleId));

            return (await _jobsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task<JobGetDTO?> UpdateAsync(int id,
                                                  JobPutDTO dto)
        {
            var model = await _jobsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(model);

            await _jobsRepository.UpdateAsync(model, update);

            return (await _jobsRepository.GetByIdAsync(id)).ToGetDTO();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _jobsRepository.GetByIdAsync(id);

            if (model.UserId != _usersService.GetCurrentUserId()) throw new ApplicationException(UnauthorizedError);

            await _jobsRepository.DeleteAsync(model);
        }
    }
}
