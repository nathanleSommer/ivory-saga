using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Queries
{
    public sealed class GetChaptersQuery : IRequest<IEnumerable<Chapter>>
    {
        public GetChaptersQuery(Guid id)
        {
            SagaId = id;
        }

        public Guid SagaId { get; } = default!;

        internal sealed class Handler : IRequestHandler<GetChaptersQuery, IEnumerable<Chapter>>
        {
            private readonly ChapterRepository _chapterService;

            public Handler(ChapterRepository service)
            {
                _chapterService = service;
            }

            public async Task<IEnumerable<Chapter>> Handle(GetChaptersQuery request, CancellationToken cancellationToken = default)
            {
                var sagas = await _chapterService.GetAsync(request.SagaId, cancellationToken);

                return sagas?.AsReadOnly() ?? Enumerable.Empty<Chapter>();
            }
        }
    }
}
