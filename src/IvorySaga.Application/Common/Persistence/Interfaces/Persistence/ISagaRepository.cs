using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Application.Common.Persistence.Interfaces.Persistence
{
    public interface ISagaRepository { 
        Saga Add(Saga saga);

        Task<Saga?> FindAsync(SagaId id);
    }
}
