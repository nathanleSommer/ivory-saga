using System;
using IvorySaga.Domain.Common.Models;
using IvorySaga.Domain.Saga.ValueObjects;

namespace IvorySaga.Domain.Saga.Entities
{
    /// <summary>
    /// Represents a chapter inside a saga.
    /// </summary>
    public sealed class Chapter : Entity<ChapterId>
    {
        public string Content { get; private set; } = default!;

        public DateTimeOffset CreatedAt { get; private set; } = default!;

        public DateTimeOffset UpdatedAt { get; private set; } = default!;

        private Chapter()
        {

        }

        private Chapter(ChapterId id, string content) : base(id)
        {
            Content = content;
        }

        public static Chapter Create(string content)
        {
            return new Chapter(ChapterId.CreateUnique(), content)
            {
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }
    }
}
