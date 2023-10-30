using Interdisciplinar2023.Data;
using Interdisciplinar2023.Models;
using Microsoft.EntityFrameworkCore;

namespace Interdisciplinar2023.Repositories;

public class ProviderRepository : IProviderRepository
{
    private readonly DataContext _context;

    public ProviderRepository(DataContext context)
    {
        _context = context;
    }

    public bool Add(Provider provider)
    {
        _context.Add(provider);
        return Save();
    }

    public bool Update(Provider prod)
    {
        _context.Update(prod);
        return Save();
    }

    public bool Delete(Provider prod)
    {
        _context.Remove(prod);
        return Save();
    }

    public bool Save()
    {
        int saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public async Task<IEnumerable<Provider?>> GetAllProviders()
    {
        return await _context.Providers.Include(p => p.Products).ToListAsync();
    }

    public async Task<Provider?> GetProviderAsync(Guid id)
    {
        return await _context.Providers.Include(p => p.Products).FirstOrDefaultAsync(i => i.Id == id);
    }
}
