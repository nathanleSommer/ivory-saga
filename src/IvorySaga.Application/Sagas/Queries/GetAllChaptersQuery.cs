//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Domain.Saga.Entities;
//using IvorySaga.Services;
//using MediatR;

//namespace IvorySaga.Queries
//{
//    public sealed class GetAllChaptersQuery : IRequest<IEnumerable<Chapter>>
//    {
//        public GetAllChaptersQuery(Guid id)
//        {
//            SagaId = id;
//        }

//        public Guid SagaId { get; } = default!;

//        internal sealed class Handler : IRequestHandler<GetAllChaptersQuery, IEnumerable<Chapter>>
//        {
//            private readonly ChapterRepository _chapterRepository;
//            private readonly SagaRepository _sagaRepository;

//            public Handler(SagaRepository sagaRepository, ChapterRepository chapterRepository)
//            {
//                _sagaRepository = sagaRepository;
//                _chapterRepository = chapterRepository;
//            }

//            public async Task<IEnumerable<Chapter>> Handle(GetAllChaptersQuery request, CancellationToken cancellationToken = default)
//            {
//                var saga = await _sagaRepository.GetAsync(request.SagaId, cancellationToken);

//                if (saga is null)
//                {
//                    throw new SagaNotFoundException(request.SagaId.ToString());
//                }

//                var chapters = await _chapterRepository.GetAsync(request.SagaId, cancellationToken);

//                return chapters?.AsReadOnly() ?? Enumerable.Empty<Chapter>();
//            }
//        }
//    }
//}
