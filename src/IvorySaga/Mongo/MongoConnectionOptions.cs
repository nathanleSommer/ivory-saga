namespace IvorySaga.Mongo
{
    public sealed class MongoConnectionOptions : IMongoConnectionOptions
    {
        public string Host { get; set; } = null!;

        public int Port { get; set; } = default!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
