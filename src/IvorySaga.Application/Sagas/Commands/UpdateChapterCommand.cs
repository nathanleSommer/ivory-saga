using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class UpdateChapterCommand : IRequest
{
    public UpdateChapterCommand(Guid chapterId, Guid sagaId, string newContent)
    {
        _chapterId = chapterId;
        _sagaId = sagaId;
        _newContent = newContent;
    }

    private readonly Guid _chapterId;
    private readonly Guid _sagaId;
    private readonly string _newContent;

    internal sealed class Handler : IRequestHandler<UpdateChapterCommand, Unit>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateChapterCommand request, CancellationToken cancellationToken = default)
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

            saga.UpdateChapter(chapter);

            await _repository.UpdateSagaAsync(saga, cancellationToken);

            return Unit.Value;
        }
    }
}
