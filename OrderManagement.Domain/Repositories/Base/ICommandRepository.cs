using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Repositories.Base;

public interface ICommandRepository<T> where T : Entity
{
    Task<Guid> Insert(T entity, CancellationToken cancellationToken = default);
    Task<T> Update(T entity, CancellationToken cancellationToken = default);
    Task<T> UpdateById(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> Delete(T entity, CancellationToken cancellationToken = default);
    Task<Guid> DeleteById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Guid>> InsertBatch(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
