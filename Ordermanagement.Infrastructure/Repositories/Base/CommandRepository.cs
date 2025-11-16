using Microsoft.EntityFrameworkCore;
using Ordermanagement.Infrastructure.Persistence;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Repositories.Base;

namespace Ordermanagement.Infrastructure.Repositories.Base;

public class CommandRepository<T> : ICommandRepository<T> where T : Entity
{
    private readonly WriteDbContext _writeDbContext;
    private readonly DbSet<T> dbSet;

    public CommandRepository(WriteDbContext writeDbContext)
    {
        _writeDbContext = writeDbContext;
        dbSet = _writeDbContext.Set<T>();
    }
    public virtual async Task<Guid> Delete(T entity, CancellationToken cancellationToken)
    {
        dbSet.Remove(entity);
        await _writeDbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public virtual async Task<Guid> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) 
        {
            throw new NullReferenceException("Id not found");
        }

        dbSet.Remove(entity);
        await _writeDbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public virtual async Task<Guid> Insert(T entity, CancellationToken cancellationToken)
    {
        await dbSet.AddAsync(entity, cancellationToken);
        await _writeDbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public virtual async Task<IEnumerable<Guid>> InsertBatch(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await dbSet.AddRangeAsync(entities, cancellationToken);
        await _writeDbContext.SaveChangesAsync(cancellationToken);

        return entities.Select(x=>x.Id).ToList();
    }

    public virtual async Task<T> Update(T entity, CancellationToken cancellationToken)
    {
        dbSet.Update(entity);
        await _writeDbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<T> UpdateById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await dbSet.FirstOrDefaultAsync(x=>x.Id == id);
        if (entity == null) 
        {
            throw new NullReferenceException("Id not found");
        }
        dbSet.Update(entity);
        await _writeDbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
