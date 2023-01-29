using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class DeleteChapterCommand : IRequest
{
    public DeleteChapterCommand(Guid sagaId, Guid chapterId)
    {
        _sagaId = sagaId;
        _chapterId = chapterId;
    }

    private readonly Guid _sagaId;
    private readonly Guid _chapterId;

    internal sealed class Handler : IRequestHandler<DeleteChapterCommand, Unit>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteChapterCommand request, CancellationToken cancellationToken = default)
        {
            var sagaId = SagaId.Create(request._sagaId);

            var saga = await _repository.FindSagaAsync(sagaId, cancellationToken);

            if (saga is null)
            {
                throw new SagaNotFoundException(request._sagaId.ToString());
            }

            var chapter = saga.Chapters.FirstOrDefault(x => x.Id == ChapterId.Create(request._chapterId));

            if (chapter is null)
            {
                throw new ChapterNotFoundException(request._sagaId.ToString(), request._chapterId.ToString());
            }

            saga.DeleteChapter(chapter);

            await _repository.UpdateSagaAsync(saga, cancellationToken);

            return Unit.Value;
        }
    }
}
