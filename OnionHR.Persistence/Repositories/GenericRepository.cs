using Microsoft.EntityFrameworkCore;
using OnionHR.Application.Contracts.Persistance;
using OnionHR.Domain.Common;
using OnionHR.Persistence.DatabaseContext;

namespace OnionHR.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HrDbContext _context; // protected allows derived repos to access dbContext on the base (as opposed to private)
    public GenericRepository(HrDbContext context)
    {
        this._context = context;
    }
    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }
    public async Task<T> CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        //_context.Update(entity); <-- either/or --vvv
        _context.Entry(entity).State = EntityState.Modified;// <-- tends to generate more efficient statement
        await _context.SaveChangesAsync();

        return entity;
    }
}
