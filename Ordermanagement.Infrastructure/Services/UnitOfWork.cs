using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Ordermanagement.Infrastructure.Persistence;
using OrderManagement.Domain.Services;

namespace Ordermanagement.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly WriteDbContext _writeDbContext;
    private readonly ReadDbContext _readDbContext;
    private IDbContextTransaction? _tx;

    public UnitOfWork(WriteDbContext writeDbContext, ReadDbContext readDbContext)
    {
        _writeDbContext = writeDbContext;
        _readDbContext = readDbContext;
    }
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        // If a transaction is already started, reuse it.
        if (_tx != null) return;
        _tx = await _writeDbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _writeDbContext.SaveChangesAsync(cancellationToken);
        if (_tx != null)
        {
            await _tx.CommitAsync(cancellationToken);
            await _tx.DisposeAsync();
            _tx = null;
        }
    }
    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if (_tx != null)
        {
            await _tx.RollbackAsync(cancellationToken);
            await _tx.DisposeAsync();
            _tx = null;
        }
    }

    public void NoTracking(CancellationToken cancellationToken = default)
    {
        _readDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public void Dispose()
    {
        _tx?.Dispose();
    }
}
