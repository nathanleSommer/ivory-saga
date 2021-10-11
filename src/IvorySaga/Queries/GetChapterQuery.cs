using System;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Queries
{
    public sealed class GetChapterQuery : IRequest<Chapter>
    {
        public GetChapterQuery(Guid sagaId, Guid chapterId)
        {
            SagaId = sagaId;
            ChapterId = chapterId;
        }

        public Guid SagaId { get; } = default!;

        public Guid ChapterId { get; } = default!;

        internal sealed class Handler : IRequestHandler<GetChapterQuery, Chapter>
        {
            private readonly ChapterRepository _chapterService;

            public Handler(ChapterRepository service)
            {
                _chapterService = service;
            }

            public async Task<Chapter> Handle(GetChapterQuery request, CancellationToken cancellationToken = default)
            {
                var chapter = await _chapterService.GetAsync(request.SagaId, request.ChapterId, cancellationToken);

                if (chapter is null)
                {
                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.ChapterId.ToString());
                }

                return chapter;
            }
        }
    }
}
