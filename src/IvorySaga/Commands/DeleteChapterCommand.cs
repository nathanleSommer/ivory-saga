﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IvorySaga.Services;
using MediatR;

namespace IvorySaga.Commands
{
    public sealed class DeleteChapterCommand : IRequest
    {
        public DeleteChapterCommand(Guid sagaId, Guid id)
        {
            SagaId = sagaId;
            Id = id;
        }

        public Guid SagaId { get; }

        public Guid Id { get; }

        internal sealed class Handler : IRequestHandler<DeleteChapterCommand, Unit>
        {
            private readonly ChapterRepository _repository;

            public Handler(ChapterRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeleteChapterCommand request, CancellationToken cancellationToken = default)
            {
                var chapter = await _repository.GetAsync(request.SagaId, request.Id, cancellationToken);

                if (chapter is null)
                {
                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.Id.ToString());
                }

                await _repository.RemoveAsync(chapter, cancellationToken);

                return Unit.Value;
            }
        }
    }
}