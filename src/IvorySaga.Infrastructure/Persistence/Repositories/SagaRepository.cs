using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.Entities;
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
        return await _dbContext.Sagas.FindAsync(keyValues: new object[] { id }, cancellationToken: cancellationToken);
    }

    public IEnumerable<Saga> FindAllSagas()
    {
        return _dbContext.Sagas.ToList();
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
        var saga = await _dbContext.Sagas.FindAsync(keyValues: new object[] { id }, cancellationToken: cancellationToken);

        if(saga is null)
        {
            return false;
        }

        var entity = _dbContext.Sagas.Remove(saga);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.State == EntityState.Deleted;
    }

    public async Task<Chapter?> FindChapterAsync(SagaId sagaId, ChapterId chapterId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Chapters.FindAsync(keyValues: new object[] { sagaId, chapterId }, cancellationToken: cancellationToken);
    }

    public async Task<Chapter> CreateChapterAsync(SagaId sagaId, Chapter chapter, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Chapters.AddAsync(chapter, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Entity;
    }

    public async Task<Chapter> UpdateChapterAsync(Chapter chapter, CancellationToken cancellationToken = default)
    {
        var entity = _dbContext.Chapters.Update(chapter);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Entity;
    }

    public async Task<bool> DeleteChapterAsync(SagaId sagaId, ChapterId chapterId, CancellationToken cancellationToken = default)
    {
        var chapter = await _dbContext.Chapters.FindAsync(keyValues: new object[] { sagaId, chapterId }, cancellationToken: cancellationToken);

        if (chapter is null)
        {
            return false;
        }

        var entity = _dbContext.Chapters.Remove(chapter);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.State == EntityState.Deleted;
    }

    public IEnumerable<Chapter> FindAllChapters(SagaId sagaId)
    {
        return _dbContext.Chapters.Where(c => c.SagaId == sagaId);
    }
}
