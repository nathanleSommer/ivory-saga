using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects.Saga
{
    public sealed class CreateChapterRequest
    {
        [Required]
        public string Content { get; set; } = default!;
    }
}
