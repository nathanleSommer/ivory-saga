namespace IvorySaga.Mongo
{
    public sealed class MongoConnectionOptions : IMongoConnectionOptions
    {
        public string Host { get; set; } = null!;

        public int Port { get; set; } = default!;

        public string RootPassword { get; set; } = null!;
    }
}
