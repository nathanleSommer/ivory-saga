using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Queries
{
    public sealed class GetSagasQuery : IRequest<IEnumerable<Saga>>
    {
        internal sealed class Handler : IRequestHandler<GetSagasQuery, IEnumerable<Saga>>
        {
            private readonly SagaRepository _sagaService;

            public Handler(SagaRepository service)
            {
                _sagaService = service;
            }

            public async Task<IEnumerable<Saga>> Handle(GetSagasQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = await _sagaService.GetAsync(cancellationToken);
                return sagas?.AsReadOnly() ?? Enumerable.Empty<Saga>();
            }
        }
    }
}
