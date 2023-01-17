using System;
using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands
{
    public record CreateSagaCommand(string Title, AuthorCommand Author) : IRequest<Saga>;

    public record AuthorCommand(string FirstName, string LastName);

    internal sealed class Handler : IRequestHandler<CreateSagaCommand, Saga>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Saga> Handle(CreateSagaCommand request, CancellationToken cancellationToken = default)
        {
            var timestamp = DateTime.UtcNow;

            var saga = Saga.Create(
                request.Title,
                Author.Create(request.Author.FirstName, request.Author.LastName));

            var result = await _repository.AddAsync(saga, cancellationToken);
            return result;
        }
    }
}
