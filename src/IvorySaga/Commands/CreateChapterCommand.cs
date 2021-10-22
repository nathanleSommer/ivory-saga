using System;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;

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
            private readonly SagaRepository _sagaRepository;
            private readonly ChapterRepository _chapterRepository;

            public Handler(SagaRepository sagaRepository, ChapterRepository chapterRepository)
            {
                _sagaRepository = sagaRepository;
                _chapterRepository = chapterRepository;
            }

            public async Task<Chapter> Handle(CreateChapterCommand request, CancellationToken cancellationToken = default)
            {
                var saga = await _sagaRepository.GetAsync(request.SagaId, cancellationToken);

                if (saga is null)
                {
                    throw new SagaNotFoundException(request.SagaId.ToString());
                }

                var timestamp = DateTimeOffset.UtcNow;

                var chapter = new Chapter
                {
                    Id = Guid.NewGuid(),
                    SagaId = request.SagaId,
                    Content = request.Content,
                    CreatedAt = timestamp,
                    UpdatedAt = timestamp,
                };

                return await _chapterRepository.CreateAsync(chapter, cancellationToken);
            }
        }
    }
}
