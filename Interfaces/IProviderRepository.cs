namespace Interdisciplinar2023.Interfaces;

public interface IProviderRepository : IRepository<Provider>
{
    Task<IEnumerable<Provider?>> GetAllProviders();

    Task<Provider?> GetProviderAsync(Guid id);

}
