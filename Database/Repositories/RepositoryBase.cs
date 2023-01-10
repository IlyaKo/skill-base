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

    protected virtual async Task<TEntity> AddAsync(TEntity entity, bool saveChanges = true)
    {
        var entry = await _set.AddAsync(entity);
        if (saveChanges)
        {
            await _context.SaveChangesAsync();
        }

        return entry.Entity;
    }

    protected virtual Task DeleteAsync(TEntity entity)
    {
        _set.Remove(entity);

        return SaveAsync();
    }

    protected virtual IQueryable<TEntity> FindById(int id, bool asNoTracking = true)
    {
        var entities = _set.AsQueryable();

        if (asNoTracking)
        {
            entities = entities.AsNoTracking();
        }

        return entities.Where(x => x.Id == id);
    }

    protected virtual IQueryable<TEntity> FindByIds(List<int> ids, bool asNoTracking = true)
    {
        var entities = _set.AsQueryable();

        if (asNoTracking)
        {
            entities = entities.AsNoTracking();
        }

        return entities.Where(x => ids.Contains(x.Id));
    }

    protected virtual IQueryable<TEntity> GetAllAsync(bool asNoTracking = true)
    {
        var query = _set.AsQueryable();
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    protected Task SaveAsync()
        => _context.SaveChangesAsync();

    protected async virtual Task UpdateAsync(TEntity entity, bool saveChanges = true)
    {
        _set.Update(entity);
        if (saveChanges)
        {
            await SaveAsync();
        }
    }

}
