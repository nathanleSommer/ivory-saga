using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Queries;

public sealed class GetAllChaptersQuery : IRequest<IEnumerable<Chapter>>
{
    public GetAllChaptersQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; } = default!;

    internal sealed class Handler : IRequestHandler<GetAllChaptersQuery, IEnumerable<Chapter>>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository sagaRepository)
        {
            _repository = sagaRepository;
        }

        public async Task<IEnumerable<Chapter>> Handle(GetAllChaptersQuery request, CancellationToken cancellationToken = default)
        {
            var saga = await _repository.FindSagaAsync(SagaId.Create(request.Id), cancellationToken);

            if (saga is null)
            {
                throw new SagaNotFoundException(request.Id.ToString());
            }

            return saga.Chapters;
        }
    }
}
