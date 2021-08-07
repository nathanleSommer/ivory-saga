using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            private readonly SagaService _sagaService;

            public Handler(SagaService service)
            {
                _sagaService = service;
            }

            public async Task<Saga> Handle(GetSagaQuery request, CancellationToken cancellationToken = default)
            {
                var saga = _sagaService.Get(request.Id.ToString());

                if (saga is null)
                {
                    throw new SagaNotFoundException(request.Id.ToString());
                }

                return saga;
            }
        }
    }
}
