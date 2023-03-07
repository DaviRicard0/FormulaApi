using FormulaApi.Data;
using FormulaApi.DTOs;
using FormulaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly FormulaApiContext _context;
    protected readonly ILogger _logger;

    public GenericRepository(ILogger logger,FormulaApiContext context)
    {
        _logger = logger;
        _context = context;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> Create(T entity) {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> Delete(T entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}
