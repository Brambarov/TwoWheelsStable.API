using TwoWheelsStable.API.Models;

namespace TwoWheelsStable.API.Services.Contracts
{
    public interface IAPINinjasService
    {
        Task<Specs> GetAsync(string make, string model, int year);
    }
}
