using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Commands
{
    public sealed class CreateChapterCommand : IRequest<Chapter>
    {
        public CreateChapterCommand(Guid sagaId, string content)
        {
            SagaId = sagaId;
            Content = content;
        }

        public Guid SagaId { get; set; } = default!;

        public string Content { get; } = default!;

        internal sealed class Handler : IRequestHandler<CreateChapterCommand, Chapter>
        {
            private readonly ChapterService _chapterService;

            public Handler(ChapterService service)
            {
                _chapterService = service;
            }

            /// <inheritdoc />
            public async Task<Chapter> Handle(CreateChapterCommand request, CancellationToken cancellationToken = default)
            {
                var timestamp = DateTimeOffset.UtcNow;

                var chapter = new Chapter
                {
                    Id = Guid.NewGuid(),
                    SagaId = request.SagaId,
                    Content = request.Content,
                };

                return _chapterService.Create(chapter);
            }
        }
    }
}
