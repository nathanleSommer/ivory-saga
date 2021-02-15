using IvorySaga.Data;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Queries
{
    public sealed class GetSagasQuery : IRequest<IEnumerable<Saga>>
    {
        public sealed class Result
        {
            public Result(IReadOnlyList<object> sagas)
            {
                Sagas = sagas;
            }

            public IReadOnlyList<object> Sagas { get; }

            public long? TotalCount { get; set; }
        }

        internal sealed class Handler : IRequestHandler<GetSagasQuery, IEnumerable<Saga>>
        {
            public Handler()
            {

            }

            public async Task<IEnumerable<Saga>> Handle(GetSagasQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = new List<Saga>()
                {
                    new Saga() { Author = "Inso", Content = "saga1" },
                    new Saga() { Author = "Inso", Content = "saga2" },
                    new Saga() { Author = "Inso", Content = "saga3" },
                };

                return sagas.AsReadOnly();
            }
        }
    }
}
