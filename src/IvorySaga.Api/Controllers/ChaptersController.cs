using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IvorySaga.Api.DataTransferObjects;
using IvorySaga.Api.Models;
using IvorySaga.Commands;
using IvorySaga.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IvorySaga.Api.Controllers
{
    [ApiController]
    [Route("v1/sagas/{SagaId}")]
    public class ChaptersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public ChaptersController(IMapper mapper, ISender sender)
        {
            _mapper = mapper;
            _sender = sender;
        }

        /// <summary>
        /// Gets the list of chapter of a saga.
        /// </summary>
        /// <param name="reference">The saga identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The chapters of the saga.</returns>
        [HttpGet("chapters")]
        public async Task<ActionResult<IReadOnlyList<ChapterModel>>> GetChapters(
            [FromRoute] SagaReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetChaptersQuery(reference.SagaId);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<IReadOnlyList<ChapterModel>>(response));
        }

        /// <summary>
        /// Gets a specific chapter of a saga.
        /// </summary>
        /// <param name="reference">The saga and chapter identifiers</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The chapter's information.</returns>
        [HttpGet("chapter/{ChapterId}")]
        public async Task<ActionResult<ChapterModel>> GetChapter(
            [FromRoute] ChapterReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetChapterQuery(reference.SagaId, reference.ChapterId);
            var response = await _sender.Send(query, cancellationToken);
            return Ok(_mapper.Map<ChapterModel>(response));
        }

        /// <summary>
        /// Creates a new chapter in a saga.
        /// </summary>
        /// <param name="reference">The saga identifier.</param>
        /// <param name="request">The chapter's content.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The newly created chapter.</returns>
        [HttpPost]
        public async Task<ActionResult<SagaModel>> CreateChapter(
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
