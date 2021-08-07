using System;
using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects
{
    public class SagaReference
    {
        [Required]
        public Guid SagaId { get; set; } = default!;
    }
}
