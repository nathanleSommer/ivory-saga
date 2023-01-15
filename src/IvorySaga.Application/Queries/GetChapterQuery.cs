//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Domain.Saga.Entities;
//using MediatR;

//namespace IvorySaga.Queries
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
//            private readonly ChapterRepository _repository;

//            public Handler(ChapterRepository repository)
//            {
//                _repository = repository;
//            }

//            public async Task<Chapter> Handle(GetChapterQuery request, CancellationToken cancellationToken = default)
//            {
//                var chapter = await _repository.GetAsync(request.SagaId, request.ChapterId, cancellationToken);

//                if (chapter is null)
//                {
//                    throw new ChapterNotFoundException(request.SagaId.ToString(), request.ChapterId.ToString());
//                }

//                return chapter;
//            }
//        }
//    }
//}
