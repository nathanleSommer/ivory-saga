using System;
using System.Collections.Generic;
using System.Linq;
using IvorySaga.Domain.Common.Models;
using IvorySaga.Domain.Saga.Entities;
using IvorySaga.Domain.Saga.ValueObjects;


namespace IvorySaga.Domain.Saga
{
    /// <summary>
    /// Represents a Saga.
    /// A saga contains chapters.
    /// </summary>
    public sealed class Saga : AggregateRoot<SagaId>
    {
        private readonly List<Chapter> _chapters = new();

        public IReadOnlyList<Chapter> Chapters => _chapters.ToList().AsReadOnly();

        public string Title { get; private set; } = default!;

        public Author Author { get; private set; } = default!;

        public DateTimeOffset CreatedAt { get; private set; } = default!;

        public DateTimeOffset UpdatedAt { get; private set; } = default!;

        private Saga()
        {

        }

        private Saga(SagaId id, string title, Author author) 
            : base(id)
        {
            Title = title;
            Author = author;
        }

        public static Saga Create(string title, Author author)
        {
            return new Saga(SagaId.CreateUnique(), title, author)
            {
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now,
            };
        }
    }
}
