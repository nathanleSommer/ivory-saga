namespace IvorySaga.Mongo
{
    public interface IMongoConnectionOptions
    {
        string Host { get; set; }

        int Port { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
