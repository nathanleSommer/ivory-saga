//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Application.Common.Persistence.Interfaces.Persistence;
//using IvorySaga.Domain.Saga.Entities;
//using MediatR;

//namespace IvorySaga.Application.Sagas.Queries
//{
//    public sealed class GetChapterQuery : IRequest<Chapter>
//    {
//        public GetChapterQuery(Guid sagaId, Guid chapterId)
//        {
//            SagaId = sagaId;
//            ChapterId = chapterId;
//        }

//        public Guid SagaId { get; } = default!;

//        public Guid ChapterId { get; } = default!;

//        internal sealed class Handler : IRequestHandler<GetChapterQuery, Chapter>
//        {
//            private readonly ISagaRepository _repository;

//            public Handler(ISagaRepository repository)
//            {
//                _repository = repository;
//            }

//            public async Task<Chapter> Handle(GetChapterQuery request, CancellationToken cancellationToken = default)
//            {
//                var chapter = await _repository.FindAsync(request.SagaId, request.ChapterId, cancellationToken);

//                if (chapter is null)
//                {
//                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.ChapterId.ToString());
//                }

//                return chapter;
//            }
//        }
//    }
//}
