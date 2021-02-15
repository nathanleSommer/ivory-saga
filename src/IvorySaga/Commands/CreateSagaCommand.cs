using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Commands
{
    public sealed class CreateSagaCommand : IRequest<Saga>
    {
        public CreateSagaCommand(string title, string author, string content)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("The title can't be null or empty", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("The author can't be null or empty", nameof(author));
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("The content can't be null or empty", nameof(content));
            }

            Title = title;
            Author = author;
            Content = content;
        }

        public string Title { get; set; }

        public string Author { get; }

        public string Content { get; }

        internal sealed class Handler : IRequestHandler<CreateSagaCommand, Saga>
        {
            private readonly SagaService _sagaService;

            public Handler(SagaService service)
            {
                _sagaService = service;
            }

            /// <inheritdoc />
            public async Task<Saga> Handle(CreateSagaCommand request, CancellationToken cancellationToken = default)
            {
                var timestamp = DateTimeOffset.UtcNow;

                var saga = new Saga
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = request.Title,
                    Author = request.Author,
                    Content = request.Content
                };

                _sagaService.Create(saga);

                return saga;
            }
        }
    }
}
