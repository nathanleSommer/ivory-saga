using System;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Queries
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
            private readonly SagaRepository _repository;

            public Handler(SagaRepository repository)
            {
                _repository = repository;
            }

            public async Task<Saga> Handle(GetSagaQuery request, CancellationToken cancellationToken = default)
            {
                var saga = await _repository.GetAsync(request.Id, cancellationToken);

                if (saga is null)
                {
                    throw new SagaNotFoundException(request.Id.ToString());
                }

                return saga;
            }
        }
    }
}
