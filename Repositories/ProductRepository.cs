using Interdisciplinar2023.Data;
using Interdisciplinar2023.Data.Enum;
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
        var response = await _context.Products
                                     .Include(p => p.Provider)
                                     .OrderBy(p => p.Validity)
                                     .ToListAsync();

        return response;

    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        var response = await _context.Products
                                        .Include(p => p.Provider)
                                        .FirstOrDefaultAsync(i => i.Id == id);

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllFromProviderAsync(Guid providerId)
    {
        var response = await _context.Products
                                        .Include(p => p.Provider)
                                        .Where(p => p.ProviderId == providerId)
                                        .OrderBy(p => p.Validity)
                                        .ToListAsync();

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllFromCategory(ProductCategory category)
    {
        var response = await _context.Products
                                     .Where(p => p.Category == category)
                                     .OrderBy(p => p.Validity)
                                     .ToListAsync();

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllFromProviderAndCategoryAsync(Guid providerId, ProductCategory category)
    {
        var response = await _context.Products
            .Include(p => p.Provider)
            .Where(p => p.ProviderId == providerId && p.Category == category)
            .OrderBy(p => p.Validity)
            .ToListAsync();

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllProductsBelowAsync(int amount)
    {
        var response = await _context.Products
            .Include(p => p.Provider)
            .Where(p => p.Quantity < amount)
            .OrderBy(p => p.Validity)
            .ToListAsync();

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllNearDateAndBelowAmount(DateTime date, int amount)
    {
        var response = await _context.Products
            .Include(p => p.Provider)
            .Where(p => p.Quantity < amount || p.Validity <= date)
            .OrderBy(p => p.Validity)
            .ToListAsync();

        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllNearDate(DateTime dueDate)
    {
        var response = await _context.Products
            .Include(p => p.Provider)
            .Where(p => p.Validity <= dueDate)
            .OrderBy(p => p.Validity)
            .ToListAsync();
        
        return response;
    }

    public async Task<IEnumerable<Product?>> GetAllNearDateAndBelowAmountFromProvider(DateTime dueDate, int amount, Guid id)
    {
        var response = await _context.Products
            .Include(p => p.Provider)
            .Where(p => p.Validity <= dueDate || p.Quantity <= amount)
            .Where(p => p.ProviderId == id)
            .OrderBy(p => p.Validity)
            .ToListAsync();

        return response;
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
