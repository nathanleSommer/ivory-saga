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
            var deleted = await _repository.DeleteChapterAsync(SagaId.Create(request._sagaId), ChapterId.Create(request._chapterId), cancellationToken);

            if (!deleted)
            {
                throw new ChapterNotDeletedException(request._sagaId.ToString(), request._chapterId.ToString());
            }

            return Unit.Value;
        }
    }
}
