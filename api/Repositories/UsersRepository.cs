using api.Helpers.Queries;
using api.Models;
using api.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static api.Helpers.Constants.ErrorMessages;

namespace api.Repositories
{
    public class UsersRepository(UserManager<User> userManager) : IUsersRepository
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<IEnumerable<User>> GetAllAsync(UserQuery query)
        {
            var models = _userManager.Users.Include(u => u.Motorcycles)
                                           .ThenInclude(m => m.Specs)
                                           .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.UserName))
            {
                models = models.Where(u => u.UserName != null
                                           && u.UserName.Contains(query.UserName));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                models = query.IsDescending ? models.OrderByDescending(m => m.UserName) : models.OrderBy(m => m.Id);
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await models.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string? id)
        {
            return await _userManager.Users.Include(u => u.Motorcycles)
                                           .ThenInclude(m => m.Specs)
                                           .FirstOrDefaultAsync(u => u.Id.Equals(id))
                   ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError,
                                                                   "User",
                                                                   "Id",
                                                                   id));
        }

        public async Task<User> GetByUserNameAsync(string? userName)
        {
            return await _userManager.Users.Include(u => u.Motorcycles)
                                           .ThenInclude(m => m.Specs)
                                           .FirstOrDefaultAsync(u => u.UserName != null
                                                                     && userName != null
                                                                     && u.UserName.Equals(userName.ToLower()))
                   ?? throw new ApplicationException(string.Format(EntityWithPropertyDoesNotExistError,
                                                                   "Job",
                                                                   "Id",
                                                                   userName)); ;
        }

        public async Task<string?> CreateAsync(User model, string password)
        {
            var createdUser = await _userManager.CreateAsync(model, password);

            if (!createdUser.Succeeded)
            {
                var error = createdUser.Errors.FirstOrDefault() ?? throw new ApplicationException(RegistrationError);

                throw new ApplicationException(error.Description);
            }

            var roleResult = await _userManager.AddToRoleAsync(model, "User");

            if (!roleResult.Succeeded)
            {
                var error = roleResult.Errors.FirstOrDefault() ?? throw new ApplicationException(RegistrationError);

                throw new ApplicationException(error.Description ?? RegistrationError);
            }

            return await _userManager.GetUserIdAsync(model);
        }

        public async Task UpdateAsync(User model, User update)
        {
            await _userManager.UpdateAsync(model);
        }

        public async Task DeleteAsync(User model)
        {
            model.IsDeleted = true;

            var result = await _userManager.UpdateAsync(model);

            if (!result.Succeeded) throw new ApplicationException(string.Format(SoftDeletionError, "User"));
        }
    }
}
