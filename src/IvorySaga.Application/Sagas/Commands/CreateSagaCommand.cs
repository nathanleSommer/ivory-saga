using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using MediatR;

namespace IvorySaga.Application.Sagas.Commands;

public sealed class CreateSagaCommand : IRequest<Saga>{

    public CreateSagaCommand(string title, AuthorCommand author)
    {
        _title = title;
        _author = author;
    }

    private readonly string _title;
    private readonly AuthorCommand _author;

    public record AuthorCommand(string Name);

    internal sealed class Handler : IRequestHandler<CreateSagaCommand, Saga>
    {
        private readonly ISagaRepository _repository;

        public Handler(ISagaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Saga> Handle(CreateSagaCommand request, CancellationToken cancellationToken = default)
        {
            var saga = Saga.Create(
                request._title,
                Author.Create(request._author.Name));

            var result = await _repository.CreateSagaAsync(saga, cancellationToken);

            return result;
        }
    }
}
