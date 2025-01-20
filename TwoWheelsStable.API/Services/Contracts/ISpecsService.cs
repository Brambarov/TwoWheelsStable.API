namespace TwoWheelsStable.API.Services.Contracts
{
    public interface ISpecsService
    {
        Task<Guid> GetOrCreateAsync(string make, string model, int year);
    }
}
