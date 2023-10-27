using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.Interfaces;

public interface IProductsRepository : IRepository<Product>
{
    Task<IEnumerable<Product?>> GetAllProductsAsync();

    Task<Product?> GetProductAsync(Guid id);
}
