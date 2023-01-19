using IvorySaga.Application.Common.Persistence.Interfaces;
using MediatR;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class DeleteSagaCommand : IRequest
{
    public DeleteSagaCommand(Guid id)
    {
        _sagaId = id;
    }

    private readonly Guid _sagaId;

    internal sealed class Handler : IRequestHandler<DeleteSagaCommand, Unit>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteSagaCommand request, CancellationToken cancellationToken = default)
        {
            var deleted = await _repository.DeleteSagaAsync(SagaId.Create(request._sagaId), cancellationToken);

            if (!deleted)
            {
                throw new SagaNotDeletedException(request._sagaId.ToString());
            }

            return Unit.Value;
        }
    }
}
