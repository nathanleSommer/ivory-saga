using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using MediatR;

namespace IvorySaga.Application.Sagas.Queries;

public sealed class GetAllSagasQuery : IRequest<IEnumerable<Saga>>
{
    internal sealed class Handler : IRequestHandler<GetAllSagasQuery, IEnumerable<Saga>>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Saga>> Handle(GetAllSagasQuery request, CancellationToken cancellationToken = default)
        {
            var sagas = _repository.FindAllSagasAsync(cancellationToken);
            return sagas;
        }
    }
}
