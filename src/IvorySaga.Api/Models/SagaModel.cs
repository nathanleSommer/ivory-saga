using System;
using System.Collections.Generic;

namespace IvorySaga.Api.Models
{
    public class SagaModel
    {
        public Guid Id { get; set; } = default!;

        public string Author { get; set; } = default!;

        public string Title { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; } = default!;

        public DateTimeOffset UpdatedAt { get; set; } = default!;
    }
}
