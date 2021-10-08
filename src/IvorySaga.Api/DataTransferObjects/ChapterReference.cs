using System;
using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects
{
    public sealed class ChapterReference
    {
        [Required]
        public Guid SagaId { get; set; } = default!;

        [Required]
        public Guid ChapterId { get; set; } = default!;
    }
}
