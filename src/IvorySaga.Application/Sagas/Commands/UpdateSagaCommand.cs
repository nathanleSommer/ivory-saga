//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using IvorySaga.Services;
//using MediatR;

//namespace IvorySaga.Commands
//{
//    public sealed class UpdateSagaCommand : IRequest
//    {
//        public UpdateSagaCommand(Guid id, string? title)
//        {
//            Id = id;
//            Title = title;
//        }

//        public Guid Id { get; set; } = default!;

//        public string? Title { get; set; }

//        internal sealed class Handler : IRequestHandler<UpdateSagaCommand, Unit>
//        {
//            private readonly SagaRepository _repository;

//            public Handler(SagaRepository repository)
//            {
//                _repository = repository;
//            }

//            public async Task<Unit> Handle(UpdateSagaCommand request, CancellationToken cancellationToken = default)
//            {
//                var timestamp = DateTimeOffset.UtcNow;

//                var saga = await _repository.GetAsync(request.Id, cancellationToken);

//                if (saga == null)
//                {
//                    throw new SagaNotFoundException(request.Id.ToString());
//                }

//                if (request.Title != null)
//                {
//                    saga.Title = request.Title;
//                    saga.UpdatedAt = timestamp;
//                }

//                await _repository.UpdateAsync(saga.Id, saga, cancellationToken);

//                return Unit.Value;
//            }
//        }
//    }
//}
