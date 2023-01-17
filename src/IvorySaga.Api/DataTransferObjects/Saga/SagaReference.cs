using System;
using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects.Saga
{
    public sealed class SagaReference
    {
        [Required]
        public Guid SagaId { get; set; } = default!;
    }
}
