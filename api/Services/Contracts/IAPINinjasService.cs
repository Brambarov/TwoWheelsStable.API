using api.Models;

namespace api.Services.Contracts
{
    public interface IAPINinjasService
    {
        Task<string?> FindMotorcycleByMakeAndModel(string make, string model);
    }
}
