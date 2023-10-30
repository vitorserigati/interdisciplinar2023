using Interdisciplinar2023.Models;
using Interdisciplinar2023.Data.Enum;

namespace Interdisciplinar2023.Interfaces;

public interface IProductsRepository : IRepository<Product>
{
    Task<IEnumerable<Product?>> GetAllFromProviderAndCategoryAsync(Guid providerId, ProductCategory category);

    Task<IEnumerable<Product?>> GetAllFromCategory(ProductCategory category);

    Task<IEnumerable<Product?>> GetAllFromProviderAsync(Guid providerId);

    Task<IEnumerable<Product?>> GetAllProductsBelowAsync(int amount);

    Task<IEnumerable<Product?>> GetAllProductsAsync();

    Task<Product?> GetProductAsync(Guid id);

}
