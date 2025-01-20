﻿using api.Models;

namespace api.Repositories.Contracts
{
    public interface IImagesRepository
    {
        Task<IEnumerable<Image>> GetByResourceIdAsync(Guid motorcycleId);
        Task<Guid> CreateAsync(Image model);
        Task DeleteAsync(Image model);
    }
}
