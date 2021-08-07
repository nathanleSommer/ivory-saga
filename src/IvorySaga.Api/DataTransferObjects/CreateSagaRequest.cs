using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects
{
    public sealed class CreateSagaRequest
    {
        [Required]
        public string Author { get; set; } = default!;

        [Required]
        public string Title { get; set; } = default!;
    }
}
