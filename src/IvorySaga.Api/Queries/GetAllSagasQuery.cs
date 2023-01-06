using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Queries
{
    public sealed class GetAllSagasQuery : IRequest<IEnumerable<Saga>>
    {
        internal sealed class Handler : IRequestHandler<GetAllSagasQuery, IEnumerable<Saga>>
        {
            private readonly SagaRepository _repository;

            public Handler(SagaRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Saga>> Handle(GetAllSagasQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = await _repository.GetAsync(cancellationToken);
                return sagas?.AsReadOnly() ?? Enumerable.Empty<Saga>();
            }
        }
    }
}
