using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Application.Common.Persistence.Interfaces;

public interface ISagaRepository
{
    Task<Saga?> FindSagaAsync(SagaId id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Saga>> FindAllSagasAsync(CancellationToken cancellationToken = default);

    Task<Saga> CreateSagaAsync(Saga saga, CancellationToken cancellationToken = default);

    Task<Saga> UpdateSagaAsync(Saga saga, CancellationToken cancellationToken = default);

    Task<bool> DeleteSagaAsync(SagaId id, CancellationToken cancellationToken = default);
}
