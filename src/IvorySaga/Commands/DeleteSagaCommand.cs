using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Commands
{
    public sealed class DeleteSagaCommand : IRequest
    {
        public DeleteSagaCommand(Guid sagaId)
        {
            SagaId = sagaId;
        }

        public Guid SagaId { get; }

        internal sealed class Handler : IRequestHandler<DeleteSagaCommand, Unit>
        {
            private readonly SagaRepository _sagaRepository;
            private readonly ChapterRepository _chapterRepository;

            public Handler(SagaRepository sagaRepository, ChapterRepository chapterRepository)
            {
                _sagaRepository = sagaRepository;
                _chapterRepository = chapterRepository;
            }

            public async Task<Unit> Handle(DeleteSagaCommand request, CancellationToken cancellationToken = default)
            {
                var saga = await _sagaRepository.GetAsync(request.SagaId, cancellationToken);

                if (saga == null)
                {
                    throw new SagaNotFoundException(request.SagaId.ToString());
                }

                // We cascade delete the chapters
                var chapters = await _chapterRepository.GetAsync(request.SagaId, cancellationToken);
                if (chapters != null)
                {
                    foreach (var chapter in chapters)
                    {
                        await _chapterRepository.RemoveAsync(chapter, cancellationToken);
                    }
                }

                await _sagaRepository.RemoveAsync(saga, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
