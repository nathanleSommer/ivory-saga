namespace IvorySaga.Infrastructure.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public sealed class Chapter
{
    [Required]
    public Guid Id { get; set; } = default!;

    [Required]
    public Guid SagaId { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    [Required]
    public DateTimeOffset CreatedAt { get; set; } = default!;

    [Required]
    public DateTimeOffset UpdatedAt { get; set; } = default!;
}
