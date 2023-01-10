using System;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Domain.Data;
using IvorySaga.Infrastructure.DataContext;
using MediatR;

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
            private readonly IvorySagaDataContext _sagaRepository;

            public Handler(IvorySagaDataContext repository)
            {
                _sagaRepository = repository;
            }

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

                var result = await _sagaRepository.AddAsync(saga, cancellationToken);

                await _sagaRepository.SaveChangesAsync(cancellationToken);

                return result;
            }
        }
    }
}
