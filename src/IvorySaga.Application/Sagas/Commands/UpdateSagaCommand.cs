using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class UpdateSagaCommand : IRequest
{
    public UpdateSagaCommand(Guid sagaId, string newTitle)
    {
        _sagaId = sagaId;
        _newTitle = newTitle;
    }

    private readonly Guid _sagaId;
    private readonly string _newTitle;

    internal sealed class Handler : IRequestHandler<UpdateSagaCommand, Unit>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSagaCommand request, CancellationToken cancellationToken = default)
        {
            var saga = await _repository.FindSagaAsync(SagaId.Create(request._sagaId), cancellationToken);

            if (saga is null)
            {
                throw new SagaNotFoundException(request._sagaId.ToString());
            }

            saga.UpdateTitle(request._newTitle);

            await _repository.UpdateSagaAsync(saga, cancellationToken);

            return Unit.Value;
        }
    }
}
