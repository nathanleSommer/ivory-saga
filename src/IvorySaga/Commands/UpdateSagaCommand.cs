﻿using IvorySaga.Data;
using IvorySaga.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Commands
{
    public sealed class UpdateSagaCommand : IRequest
    {
        public UpdateSagaCommand(Guid id, string? title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; set; } = default!;

        public string? Title { get; set; }

        internal sealed class Handler : IRequestHandler<UpdateSagaCommand, Unit>
        {
            private readonly SagaRepository _sagaService;

            public Handler(SagaRepository service)
            {
                _sagaService = service;
            }

            /// <inheritdoc />
            public async Task<Unit> Handle(UpdateSagaCommand request, CancellationToken cancellationToken = default)
            {
                var timestamp = DateTimeOffset.UtcNow;

                var saga = await _sagaService.GetAsync(request.Id, cancellationToken);

                if (saga == null) 
                {
                    throw new SagaNotFoundException(request.Id.ToString());
                }

                if (request.Title != null)
                {
                    saga.Title = request.Title;
                    saga.UpdatedAt = timestamp;
                }

                await _sagaService.UpdateAsync(saga.Id, saga, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
