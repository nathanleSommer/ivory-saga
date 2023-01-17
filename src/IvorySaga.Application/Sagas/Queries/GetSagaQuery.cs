using System;
using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Queries
{
    public sealed class GetSagaQuery : IRequest<Saga>
    {
        public GetSagaQuery(Guid sagaId)
        {
            Id = sagaId;
        }

        public Guid Id { get; set; } = default!;

        internal sealed class Handler : IRequestHandler<GetSagaQuery, Saga>
        {
            private readonly ISagaRepository _repository;

            public Handler(ISagaRepository repository)
            {
                _repository = repository;
            }

            public async Task<Saga> Handle(GetSagaQuery request, CancellationToken cancellationToken = default)
            {
                var saga = await _repository.FindAsync(SagaId.Create(request.Id), cancellationToken);

                if (saga is null)
                {
                    throw new SagaNotFoundException(request.Id.ToString());
                }

                return saga;
            }
        }
    }
}
