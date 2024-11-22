using api.DTOs.Job;
using api.Helpers.Mappers;
using api.Helpers.Queries;
using api.Repositories.Contracts;
using api.Services.Contracts;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Services
{
    public class JobsService(IUsersService usersService,
                             IJobsRepository jobsRepository) : IJobsService
    {
        private readonly IUsersService _usersService = usersService;
        private readonly IJobsRepository _jobsRepository = jobsRepository;

        public async Task<IEnumerable<JobGetDTO>> GetAllByMotorcycleIdAsync(int motorcycleId,
                                                              JobQuery query)
        {
            var models = await _jobsRepository.GetAllByMotorcycleIdAsync(motorcycleId, query);

            return models.Select(j => j.ToGetDTO());
        }

        public async Task<JobGetDTO?> GetByIdAsync(int id)
        {
            var model = await _jobsRepository.GetByIdAsync(id) ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError, "Job", "Id", id.ToString()));

            return model.ToGetDTO();
        }

        public async Task<JobGetDTO?> CreateAsync(int motorcycleId,
                                                  JobPostDTO dto)
        {
            var userId = _usersService.GetId() ?? throw new ApplicationException(UnauthorizedError);

            var id = await _jobsRepository.CreateAsync(dto.FromPostDTO(userId, motorcycleId));

            var model = await _jobsRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<JobGetDTO?> UpdateAsync(int id,
                                                  JobPutDTO dto)
        {
            var model = await _jobsRepository.GetByIdAsync(id) ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError, "Job", "Id", id.ToString()));

            var userId = _usersService.GetId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            var update = dto.FromPutDTO(id);

            await _jobsRepository.UpdateAsync(model, update);

            model = await _jobsRepository.GetByIdAsync(id);

            if (model == null) return null;

            return model.ToGetDTO();
        }

        public async Task<JobGetDTO?> DeleteAsync(int id)
        {
            var model = await _jobsRepository.GetByIdAsync(id) ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError, "Job", "Id", id.ToString()));

            var userId = _usersService.GetId();
            if (model.UserId != userId) throw new ApplicationException(UnauthorizedError);

            await _jobsRepository.DeleteAsync(model);

            return model.ToGetDTO();
        }
    }
}
