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
    [Route("v1/sagas/{SagaId}")]
    public class ChaptersController : ControllerBase
    {
        private readonly ILogger<ChaptersController> _logger;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public ChaptersController(ILogger<ChaptersController> logger, IMapper mapper, ISender sender)
        {
            _logger = logger;
            _mapper = mapper;
            _sender = sender;
        }

        [HttpGet("chapters")]
        public async Task<ActionResult<IReadOnlyList<SagaModel>>> GetChaptersAsync(
            [FromRoute] SagaReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetChaptersQuery(reference.SagaId);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<IReadOnlyList<ChapterModel>>(response));
        }

        [HttpGet("chapter/{ChapterId}")]
        public async Task<ActionResult<IReadOnlyList<SagaModel>>> GetChapterAsync(
            [FromRoute] ChapterReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetChapterQuery(reference.SagaId, reference.ChapterId);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<IReadOnlyList<ChapterModel>>(response));
        }

        [HttpPost]
        public async Task<ActionResult<SagaModel>> CreateChapterAsync(
            [FromRoute] SagaReference reference,
            [FromBody] CreateChapterRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateChapterCommand(reference.SagaId, request.Content);
            var response = await _sender.Send(command, cancellationToken);
            return Ok(_mapper.Map<ChapterModel>(response));
        }
    }
}
