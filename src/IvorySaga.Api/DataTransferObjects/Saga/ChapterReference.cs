using System;
using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects.Saga
{
    public sealed class ChapterReference
    {
        [Required]
        public Guid SagaId { get; set; } = default!;

        [Required]
        public Guid ChapterId { get; set; } = default!;
    }
}
