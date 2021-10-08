using System;

namespace IvorySaga.Api.Models
{
    public class ChapterModel
    {
        public Guid Id { get; set; } = default!;

        public Guid SagaId { get; set; } = default!;

        public string Content { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; } = default!;

        public DateTimeOffset UpdatedAt { get; set; } = default!;
    }
}
