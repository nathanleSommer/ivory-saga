//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Infrastructure.Entities;
//using IvorySaga.Infrastructure.Persistence;
//using MediatR;

//namespace IvorySaga.Commands
//{
//    public sealed class DeleteSagaCommand : IRequest
//    {
//        public DeleteSagaCommand(Guid sagaId)
//        {
//            SagaId = sagaId;
//        }

//        public Guid SagaId { get; }

//        internal sealed class Handler : IRequestHandler<DeleteSagaCommand, Unit>
//        {
//            private readonly IvorySagaDbContext _sagaRepository;
//            private readonly ChapterDataContext _chapterRepository;

//            public Handler(IvorySagaDbContext sagaRepository, ChapterDataContext chapterRepository)
//            {
//                _sagaRepository = sagaRepository;
//                _chapterRepository = chapterRepository;
//            }

//            public async Task<Unit> Handle(DeleteSagaCommand request, CancellationToken cancellationToken = default)
//            {
//                var saga = await _sagaRepository.FindAsync(typeof(Saga), request.SagaId, cancellationToken);

//                if (saga == null)
//                {
//                    throw new SagaNotFoundException(request.SagaId.ToString());
//                }

//                // We cascade delete the chapters
//                var chapters = await _chapterRepository.FindAsync(typeof(Chapter), request.SagaId, cancellationToken);
//                if (chapters != null)
//                {
//                    foreach (var chapter in chapters)
//                    {
//                        _chapterRepository.Remove(chapter, cancellationToken);
//                    }

//                    await _chapterRepository.SaveChangesAsync(cancellationToken);
//                }

//                _sagaRepository.Remove(saga, cancellationToken);

//                await _sagaRepository.SaveChangesAsync(cancellationToken);

//                return Unit.Value;
//            }
//        }
//    }
//}
