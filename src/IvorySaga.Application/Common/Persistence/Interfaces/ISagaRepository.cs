using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Application.Common.Persistence.Interfaces;

public interface ISagaRepository
{
    Task<Saga?> FindSagaAsync(SagaId id, CancellationToken cancellationToken = default);

    IEnumerable<Saga> FindAllSagas();

    Task<Saga> CreateSagaAsync(Saga saga, CancellationToken cancellationToken = default);

    Task<Saga> UpdateSagaAsync(Saga saga, CancellationToken cancellationToken = default);

    Task<bool> DeleteSagaAsync(SagaId id, CancellationToken cancellationToken = default);

    Task<Chapter?> FindChapterAsync(SagaId sagaId, ChapterId chapterId, CancellationToken cancellationToken = default);

    Task<Chapter> CreateChapterAsync(SagaId sagaId, Chapter chapter, CancellationToken cancellationToken = default);

    Task<Chapter> UpdateChapterAsync(Chapter chapter, CancellationToken cancellationToken = default);

    Task<bool> DeleteChapterAsync(SagaId id, ChapterId chapterId, CancellationToken cancellationToken = default);

    IEnumerable<Chapter> FindAllChapters(SagaId sagaId);
}
