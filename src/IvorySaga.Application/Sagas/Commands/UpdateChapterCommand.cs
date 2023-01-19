using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class UpdateChapterCommand : IRequest
{
    public UpdateChapterCommand(Guid id, Guid sagaId, string newContent)
    {
        _chapterId = id;
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
            var chapter = await _repository.FindChapterAsync(SagaId.Create(request._sagaId), ChapterId.Create(request._chapterId), cancellationToken);

            if (chapter is null)
            {
                throw new ChapterNotFoundException(request._sagaId.ToString(), request._chapterId.ToString());
            }

            chapter.UpdateContent(request._newContent);

            await _repository.UpdateChapterAsync(chapter, cancellationToken);

            return Unit.Value;
        }
    }
}
