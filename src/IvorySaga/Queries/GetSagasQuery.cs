using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Queries
{
    public sealed class GetSagasQuery : IRequest<IEnumerable<Saga>>
    {
        internal sealed class Handler : IRequestHandler<GetSagasQuery, IEnumerable<Saga>>
        {
            private readonly SagaService _sagaService;

            public Handler(SagaService service)
            {
                _sagaService = service;
            }

            public async Task<IEnumerable<Saga>> Handle(GetSagasQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = _sagaService.Get();

                return sagas?.AsReadOnly() ?? Enumerable.Empty<Saga>();
            }
        }
    }
}
