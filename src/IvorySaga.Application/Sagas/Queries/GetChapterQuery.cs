using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Queries;

public sealed class GetChapterQuery : IRequest<Chapter>
{
    public GetChapterQuery(Guid sagaId, Guid chapterId)
    {
        _sagaId = sagaId;
        _chapterId = chapterId;
    }

    private readonly Guid _sagaId;
    private readonly Guid _chapterId;

    internal sealed class Handler : IRequestHandler<GetChapterQuery, Chapter>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Chapter> Handle(GetChapterQuery request, CancellationToken cancellationToken = default)
        {
            var chapter = await _repository.FindChapterAsync(SagaId.Create(request._sagaId), ChapterId.Create(request._chapterId), cancellationToken);

            if (chapter is null)
            {
                throw new ChapterNotFoundException(request._sagaId.ToString(), request._chapterId.ToString());
            }

            return chapter;
        }
    }
}
