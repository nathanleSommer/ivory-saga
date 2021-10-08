using System;
using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects
{
    public sealed class SagaReference
    {
        [Required]
        public Guid SagaId { get; set; } = default!;
    }
}
