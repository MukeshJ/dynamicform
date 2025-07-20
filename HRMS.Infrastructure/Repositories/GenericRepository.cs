using HRMS.Application.Interfaces;
using HRMS.Domain.Entities;
using HRMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HRMSDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(HRMSDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.Where(e => !e.IsDeleted).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(e => !e.IsDeleted).Where(expression).ToListAsync();
    }

    public async Task<T?> FindFirstAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(e => !e.IsDeleted).FirstOrDefaultAsync(expression);
    }

    public async Task AddAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedAt = DateTime.UtcNow;
        entity.IsDeleted = false;
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsDeleted = false;
        }
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        entity.IsDeleted = true;
        entity.UpdatedAt = DateTime.UtcNow;
        _dbSet.Update(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.UtcNow;
        }
        _dbSet.UpdateRange(entities);
    }

    public async Task<int> CountAsync()
    {
        return await _dbSet.CountAsync(e => !e.IsDeleted);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(e => !e.IsDeleted).CountAsync(expression);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(e => !e.IsDeleted).AnyAsync(expression);
    }
}