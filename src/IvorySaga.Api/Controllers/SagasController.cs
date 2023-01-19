using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IvorySaga.Api.DataTransferObjects.Saga;
using IvorySaga.Application.Sagas.Commands;
using IvorySaga.Application.Sagas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IvorySaga.Api.Controllers;

[ApiController]
[Route("v1/sagas")]
public class SagasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public SagasController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    /// <summary>
    /// Creates a new saga.
    /// </summary>
    /// <param name="request">The saga's information.</param>
    /// <param name="cancellationToken">The cancellationToken.</param>
    /// <returns>The newly created saga.</returns>
    [HttpPost]
    public async Task<ActionResult<SagaResponse>> CreateSaga(
        [FromBody] CreateSagaRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<CreateSagaCommand>(request);
        var response = await _sender.Send(command, cancellationToken);

        return Ok(_mapper.Map<SagaResponse>(response));
    }

    /// <summary>
    /// Gets a saga.
    /// </summary>
    /// <param name="reference">The saga identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The saga's information.</returns>
    [HttpGet("{SagaId}")]
    public async Task<ActionResult<IReadOnlyList<SagaResponse>>> GetSaga(
        [FromRoute] SagaReference reference,
        CancellationToken cancellationToken)
    {
        var query = new GetSagaQuery(reference.SagaId);

        try
        {
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<SagaResponse>(response));
        }
        catch (SagaNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Gets the available sagas.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The sagas' information.</returns>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SagaResponse>>> GetSagas(CancellationToken cancellationToken)
    {
        var query = new GetAllSagasQuery();
        var response = await _sender.Send(query, cancellationToken);
        return Ok(_mapper.Map<IReadOnlyList<SagaResponse>>(response));
    }

    /// <summary>
    /// Updates an existing saga.
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
        var command = new UpdateSagaCommand(reference.SagaId, request.NewTitle);

        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (SagaNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing saga.
    /// </summary>
    /// <param name="reference">The saga identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No content.</returns>
    [HttpDelete("{SagaId}")]
    public async Task<ActionResult> DeleteSaga(
        [FromRoute] SagaReference reference,
        CancellationToken cancellationToken)
    {
        var command = new DeleteSagaCommand(reference.SagaId);

        try
        {
            await _sender.Send(command, cancellationToken);
        }
        catch (SagaNotFoundException e)
        {
            return NotFound(e.Message);
        }

        return NoContent();
    }
}
