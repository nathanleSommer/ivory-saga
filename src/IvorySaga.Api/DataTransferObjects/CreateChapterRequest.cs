using System.ComponentModel.DataAnnotations;

namespace IvorySaga.Api.DataTransferObjects
{
    public sealed class CreateChapterRequest
    {
        [Required]
        public string Content { get; set; } = default!;
    }
}
