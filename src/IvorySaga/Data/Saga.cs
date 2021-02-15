using System;

namespace IvorySaga.Data
{
    /// <summary>
    /// Represents a Saga.
    /// </summary>
    public sealed class Saga
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
