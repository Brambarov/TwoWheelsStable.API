namespace api.Services.Contracts
{
    public interface ISpecsService
    {
        Task<int?> GetOrCreateAsync(string make, string model, int year);
    }
}
