using System;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Domain.Data;
using IvorySaga.Infrastructure.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Commands
{
    public sealed class CreateChapterCommand : IRequest<Chapter>
    {
        public CreateChapterCommand(Guid sagaId, string content)
        {
            SagaId = sagaId;
            Content = content;
        }

        public Guid SagaId { get; set; } = default!;

        public string Content { get; } = default!;

        internal sealed class Handler : IRequestHandler<CreateChapterCommand, Chapter>
        {
            private readonly IvorySagaDataContext _repository;

            public Handler(IvorySagaDataContext repository)
            {
                _repository = repository;
            }

            public async Task<Chapter> Handle(CreateChapterCommand request, CancellationToken cancellationToken = default)
            {
                var saga = await _repository.Sagas.FindAsync(request.SagaId, cancellationToken);

                if (saga is null)
                {
                    throw new SagaNotFoundException(request.SagaId.ToString());
                }

                var timestamp = DateTimeOffset.UtcNow;

                var chapter = new Chapter
                {
                    Id = Guid.NewGuid(),
                    SagaId = request.SagaId,
                    Content = request.Content,
                    CreatedAt = timestamp,
                    UpdatedAt = timestamp,
                };

                return await _repository.Chapters.AddAsync<Chapter>(chapter, cancellationToken);
            }
        }
    }
}
