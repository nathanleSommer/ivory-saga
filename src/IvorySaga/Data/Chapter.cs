using System;

namespace IvorySaga.Data
{
    /// <summary>
    /// Represents a chapter inside a saga.
    /// </summary>
    public sealed class Chapter
    {
        public Guid Id { get; set; } = default!;

        public Guid SagaId { get; set; } = default!;

        public string Content { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; } = default!;

        public DateTimeOffset UpdatedAt { get; set; } = default!;
    }
}
