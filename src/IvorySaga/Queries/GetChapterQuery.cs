using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Queries
{
    public sealed class GetChapterQuery : IRequest<Chapter>
    {
        public Guid SagaId { get; } = default!;
        public Guid ChapterId { get; } = default!;

        public GetChapterQuery(Guid sagaId, Guid chapterId)
        {
            SagaId = sagaId;
            ChapterId = chapterId;
        }

        internal sealed class Handler : IRequestHandler<GetChapterQuery, Chapter>
        {
            private readonly ChapterService _chapterService;

            public Handler(ChapterService service)
            {
                _chapterService = service;
            }

            public async Task<Chapter> Handle(GetChapterQuery request, CancellationToken cancellationToken = default)
            {
                var chapter = _chapterService.Get(request.SagaId.ToString(), request.ChapterId.ToString());

                if (chapter is null)
                {
                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.ChapterId.ToString());
                }

                return chapter;
            }
        }
    }
}
