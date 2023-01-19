using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class CreateChapterCommand : IRequest<Chapter>
{
    public CreateChapterCommand(Guid sagaId, string content)
    {
        _sagaId = sagaId;
        _content = content;
    }

    private readonly Guid _sagaId;
    private readonly string _content;

    internal sealed class Handler : IRequestHandler<CreateChapterCommand, Chapter>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Chapter> Handle(CreateChapterCommand request, CancellationToken cancellationToken = default)
        {
            return await _repository.CreateChapterAsync(SagaId.Create(request._sagaId), Chapter.Create(request._content), cancellationToken);
        }
    }
}
