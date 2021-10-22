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
    [Route("v1/sagas/{SagaId}/chapters")]
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
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ChapterModel>>> GetChapters(
            [FromRoute] SagaReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetAllChaptersQuery(reference.SagaId);

            try
            {
                var response = await _sender.Send(query, cancellationToken);
                return Ok(_mapper.Map<IReadOnlyList<ChapterModel>>(response));
            }
            catch (SagaNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Gets a specific chapter of a saga.
        /// </summary>
        /// <param name="reference">The saga and chapter identifiers.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The chapter's information.</returns>
        [HttpGet("{ChapterId}")]
        public async Task<ActionResult<ChapterModel>> GetChapter(
            [FromRoute] ChapterReference reference,
            CancellationToken cancellationToken)
        {
            var query = new GetChapterQuery(reference.SagaId, reference.ChapterId);

            try
            {
                var response = await _sender.Send(query, cancellationToken);
                return Ok(_mapper.Map<ChapterModel>(response));
            }
            catch (ChapterNotFoundException e)
            {
                return NotFound(e.Message);
            }
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

            try
            {
                var response = await _sender.Send(command, cancellationToken);
                return Ok(_mapper.Map<ChapterModel>(response));
            }
            catch (SagaNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        /// <summary>
        /// Updates an existing chapter.
        /// </summary>
        /// <param name="reference">The chapter identifier.</param>
        /// <param name="request">The chapter's information to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpPatch("{ChapterId}")]
        public async Task<ActionResult> UpdateChapter(
            [FromRoute] ChapterReference reference,
            [FromBody] UpdateChapterRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateChapterCommand(reference.SagaId, reference.ChapterId, request.Content);

            try
            {
                await _sender.Send(command, cancellationToken);
            }
            catch (ChapterNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing chapter.
        /// </summary>
        /// <param name="reference">The chapter identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{ChapterId}")]
        public async Task<ActionResult> DeleteChapter(
            [FromRoute] ChapterReference reference,
            CancellationToken cancellationToken)
        {
            var command = new DeleteChapterCommand(reference.SagaId, reference.ChapterId);

            try
            {
                await _sender.Send(command, cancellationToken);
            }
            catch (ChapterNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }
    }
}
