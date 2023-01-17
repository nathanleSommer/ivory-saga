//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Services;
//using MediatR;

//namespace IvorySaga.Commands
//{
//    public sealed class UpdateChapterCommand : IRequest
//    {
//        public UpdateChapterCommand(Guid id, Guid sagaId, string? content)
//        {
//            Id = id;
//            SagaId = sagaId;
//            Content = content;
//        }

//        public Guid Id { get; set; } = default!;

//        public Guid SagaId { get; } = default!;

//        public string? Content { get; set; }

//        internal sealed class Handler : IRequestHandler<UpdateChapterCommand, Unit>
//        {
//            private readonly ChapterRepository _repository;

//            public Handler(ChapterRepository repository)
//            {
//                _repository = repository;
//            }

//            public async Task<Unit> Handle(UpdateChapterCommand request, CancellationToken cancellationToken = default)
//            {
//                var timestamp = DateTimeOffset.UtcNow;

//                var chapter = await _repository.GetAsync(request.SagaId, request.Id, cancellationToken);

//                if (chapter == null)
//                {
//                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.Id.ToString());
//                }

//                if (request.Content != null)
//                {
//                    chapter.Content = request.Content;
//                    chapter.UpdatedAt = timestamp;
//                }

//                await _repository.UpdateAsync(chapter.Id, chapter, cancellationToken);

//                return Unit.Value;
//            }
//        }
//    }
//}
