using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Application.Common.Persistence.Interfaces
{
    public interface ISagaRepository
    {
        Task<Saga> AddAsync(Saga saga, CancellationToken cancellationToken = default);

        Task<Saga?> FindAsync(SagaId id, CancellationToken cancellationToken = default);
    }
}
