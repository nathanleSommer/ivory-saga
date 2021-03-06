﻿using AutoMapper;
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

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SagaModel>>> GetSagaAsync(CancellationToken cancellationToken)
        {
            var query = new GetSagasQuery();
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<IReadOnlyList<SagaModel>>(response));
        }

        [HttpPost]
        public async Task<ActionResult<SagaModel>> CreateSagaAsync(
            [FromBody] CreateSagaRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateSagaCommand(request.Title, request.Author, request.Content);
            var response = await _sender.Send(command, cancellationToken);
            return Ok(_mapper.Map<SagaModel>(response));
        }
    }
}
