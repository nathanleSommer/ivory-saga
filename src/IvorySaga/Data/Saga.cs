using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IvorySaga.Data
{
    /// <summary>
    /// Represents a Saga.
    /// </summary>
    public sealed class Saga
    {
        [BsonId]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }
    }
}
