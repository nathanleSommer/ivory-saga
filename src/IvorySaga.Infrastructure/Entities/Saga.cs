namespace IvorySaga.Infrastructure.Entities;

using System.ComponentModel.DataAnnotations;

public sealed class Saga
{
    [Required]
    public Guid Id { get; set; } = default!;

    [Required]
    public string Title { get; set; } = default!;

    [Required]
    public string Author { get; set; } = default!;

    [Required]
    public DateTimeOffset CreatedAt { get; set; } = default!;

    [Required]
    public DateTimeOffset UpdatedAt { get; set; } = default!;

    public List<Chapter> Chapters { get; set; } = default!;
}
