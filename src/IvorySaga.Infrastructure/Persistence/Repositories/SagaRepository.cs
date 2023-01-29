using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.Persistence.Repositories;

public class SagaRepository : ISagaRepository
{
    private readonly IvorySagaDbContext _dbContext;

    public SagaRepository(IvorySagaDbContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Saga?> FindSagaAsync(SagaId id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Sagas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Saga>> FindAllSagasAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Sagas.ToListAsync(cancellationToken);
    }

    public async Task<Saga> CreateSagaAsync(Saga saga, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Sagas.AddAsync(saga, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Entity;
    }

    public async Task<Saga> UpdateSagaAsync(Saga saga, CancellationToken cancellationToken = default)
    {
        var entity = _dbContext.Sagas.Update(saga);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Entity;
    }

    public async Task<bool> DeleteSagaAsync(SagaId id, CancellationToken cancellationToken = default)
    {
        var saga = await _dbContext.Sagas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if(saga is null)
        {
            return false;
        }

        var entity = _dbContext.Sagas.Remove(saga);
        var deleted = entity.State == EntityState.Deleted;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return deleted;
    }
}
