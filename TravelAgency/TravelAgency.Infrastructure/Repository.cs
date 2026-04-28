using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Infrastructure;

public class Repository<T> where T : class
{
    private readonly TravelAgencyContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(TravelAgencyContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}