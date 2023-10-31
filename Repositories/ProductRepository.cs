using Interdisciplinar2023.Data;
using Interdisciplinar2023.Data.Enum;
using Interdisciplinar2023.Models;
using Microsoft.EntityFrameworkCore;

namespace Interdisciplinar2023.Repositories;

public class ProductRepository : IProductsRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product?>> GetAllProductsAsync()
    {
        return await _context.Products.Include(p => p.Provider).ToListAsync();

    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        return await _context.Products.Include(p => p.Provider).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Product?>> GetAllFromProviderAsync(Guid providerId)
    {
        return await _context.Products.Include(p => p.Provider).Where(p => p.ProviderId == providerId).ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetAllFromCategory(ProductCategory category)
    {
        return await _context.Products.Where(p => p.Category == category).ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetAllFromProviderAndCategoryAsync(Guid providerId, ProductCategory category)
    {
        return await _context.Products.Include(p => p.Provider).Where(p => p.ProviderId == providerId && p.Category == category).ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetAllProductsBelowAsync(int amount)
    {
        return await _context.Products.Include(p => p.Provider).Where(p => p.Quantity < amount).ToListAsync();
    }

    public async Task<IEnumerable<Product?>> GetAllNearDate(DateTime dueDate){
        return await _context.Products.Include(p=> p.Provider).Where(p => p.Validity <= dueDate).ToListAsync();
    }
    public bool Update(Product prod)
    {
        _context.Update(prod);
        return Save();
    }

    public bool Save()
    {
        int saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool Add(Product prod)
    {
        _context.Add(prod);
        return Save();
    }

    public bool Delete(Product prod)
    {
        _context.Remove(prod);
        return Save();
    }

}
