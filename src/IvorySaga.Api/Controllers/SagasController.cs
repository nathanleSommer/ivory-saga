using AutoMapper;
using IvorySaga.Api.DataTransferObjects;
using IvorySaga.Api.Models;
using IvorySaga.Commands;
using IvorySaga.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Api.Controllers
{
    [ApiController]
    [Route("v1/sagas")]
    public class SagasController : ControllerBase
    {
        private readonly ILogger<SagasController> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public SagasController(ILogger<SagasController> logger, IMapper mapper, ISender sender)
        {
            _logger = logger;
            _mapper = mapper;
            _sender = sender;
        }

        /// <summary>
        /// Gets the available sagas.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The sagas' information.</returns>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SagaModel>>> GetSagas(CancellationToken cancellationToken)
        {
            var query = new GetSagasQuery();
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<IReadOnlyList<SagaModel>>(response));
        }

        /// <summary>
        /// Gets a saga.
        /// </summary>
        /// <param name="reference">The saga identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The saga's information.</returns>
        [HttpGet("{SagaId}")]
        public async Task<ActionResult<IReadOnlyList<SagaModel>>> GetSaga(
            [FromRoute] SagaReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetSagaQuery(reference.SagaId);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<SagaModel>(response));
        }

        /// <summary>
        /// Creates a new saga.
        /// </summary>
        /// <param name="request">The saga's information.</param>
        /// <param name="cancellationToken">The cancellationToken</param>
        /// <returns>The newly created saga.</returns>
        [HttpPost]
        public async Task<ActionResult<SagaModel>> CreateSaga(
            [FromBody] CreateSagaRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateSagaCommand(request.Title, request.Author);
            var response = await _sender.Send(command, cancellationToken);
            return Ok(_mapper.Map<SagaModel>(response));
        }

        /// <summary>
        /// Update an existing saga.
        /// </summary>
        /// <param name="reference">The saga identifier.</param>
        /// <param name="request">The saga's information to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpPatch("{SagaId}")]
        public async Task<ActionResult> UpdateSaga(
            [FromRoute] SagaReference reference,
            [FromBody] UpdateSagaRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateSagaCommand(reference.SagaId, request.Title);
            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
