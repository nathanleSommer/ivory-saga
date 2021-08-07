using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Queries
{
    public sealed class GetChaptersQuery : IRequest<IEnumerable<Chapter>>
    {
        public Guid SagaId { get; } = default!;

        public GetChaptersQuery(Guid id)
        {
            SagaId = id;
        }

        internal sealed class Handler : IRequestHandler<GetChaptersQuery, IEnumerable<Chapter>>
        {
            private readonly ChapterService _chapterService;

            public Handler(ChapterService service)
            {
                _chapterService = service;
            }

            public async Task<IEnumerable<Chapter>> Handle(GetChaptersQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = _chapterService.Get(request.SagaId.ToString());

                return sagas?.AsReadOnly() ?? Enumerable.Empty<Chapter>();
            }
        }
    }
}
