using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IvorySaga.Data
{
    /// <summary>
    /// Represents a Saga.
    /// A saga contains chapters.
    /// </summary>
    public sealed class Saga
    {
        [BsonId]
        public string Id { get; set; } = default!;

        public string Title { get; set; } = default!;

        public string Author { get; set; } = default!;

        public IEnumerable<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
