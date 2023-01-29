using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Queries;

public sealed class GetSagaQuery : IRequest<Saga>
{
    public GetSagaQuery(Guid sagaId)
    {
        _sagaId = sagaId;
    }

    private readonly Guid _sagaId;

    internal sealed class Handler : IRequestHandler<GetSagaQuery, Saga>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Saga> Handle(GetSagaQuery request, CancellationToken cancellationToken = default)
        {
            var saga = await _repository.FindSagaAsync(SagaId.Create(request._sagaId), cancellationToken);

            if (saga is null)
            {
                throw new SagaNotFoundException(request._sagaId.ToString());
            }

            return saga;
        }
    }
}
