using Microsoft.EntityFrameworkCore;
using OnionArc.Application.Abstract;
using OnionArc.Persistence.Context;
using System.Linq.Expressions;

namespace OnionArc.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class, new()
{
    private readonly DatabaseContext _context;

    public Repository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        => await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);

    public async Task<T?> GetByIdAsync(object id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
