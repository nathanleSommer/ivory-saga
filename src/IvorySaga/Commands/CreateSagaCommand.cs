using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Commands
{
    public sealed class CreateSagaCommand : IRequest<Saga>
    {
        public CreateSagaCommand(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Title { get; set; } = default!;

        public string Author { get; } = default!;

        internal sealed class Handler : IRequestHandler<CreateSagaCommand, Saga>
        {
            private readonly SagaRepository _sagaService;

            public Handler(SagaRepository service)
            {
                _sagaService = service;
            }

            /// <inheritdoc />
            public async Task<Saga> Handle(CreateSagaCommand request, CancellationToken cancellationToken = default)
            {
                var timestamp = DateTimeOffset.UtcNow;

                var saga = new Saga
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Author = request.Author,
                    CreatedAt = timestamp,
                    UpdatedAt = timestamp,
                };

                var result = await _sagaService.CreateAsync(saga, cancellationToken);

                return result;
            }
        }
    }
}
