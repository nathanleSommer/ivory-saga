using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IvorySaga.Data
{
    /// <summary>
    /// Represents a Saga.
    /// A saga contains chapters.
    /// </summary>
    public sealed class Saga
    {
        //[BsonId]
        public Guid Id { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string Author { get; set; } = default!;

        public DateTimeOffset CreatedAt { get; set; } = default!;

        public DateTimeOffset UpdatedAt { get; set; } = default!;
    }
}
