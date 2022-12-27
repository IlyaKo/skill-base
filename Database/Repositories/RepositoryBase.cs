using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories;

public abstract class RepositoryBase<TEntity> where TEntity : EntityBase
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _set;

    public RepositoryBase(DbContext context)
    {
        _context = context;
        _set = context.Set<TEntity>();
    }

    protected virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var entry = await _set.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entry.Entity;
    }

    protected virtual Task DeleteAsync(TEntity entity)
    {
        _set.Remove(entity);

        return SaveAsync();
    }

    protected virtual IQueryable<TEntity> FindById(int id, bool asNoTracking = true, params string[] includePaths)
    {
        var entities = _set.AsQueryable();

        if (asNoTracking)
        {
            entities = entities.AsNoTracking();
        }

        if (includePaths.Length > 0)
        {
            entities = AddIncludes(entities, includePaths);
        }

        return entities.Where(x => x.Id == id);
    }

    protected virtual IQueryable<TEntity> GetAllAsync(string[] includePaths = null)
    {
        var entities = _set.AsQueryable().AsNoTracking();

        if (includePaths?.Any() == true)
        {
            entities = AddIncludes(entities, includePaths);
        }

        return entities;
    }

    protected Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    protected virtual Task UpdateAsync(TEntity entity)
    {
        _set.Update(entity);

        return SaveAsync();
    }

    protected virtual IQueryable<TEntity> AddIncludes(IQueryable<TEntity> entities, IEnumerable<string> includePaths)
    {
        return includePaths.Aggregate(entities, (current, includePath) => current.Include(includePath));
    }
}
