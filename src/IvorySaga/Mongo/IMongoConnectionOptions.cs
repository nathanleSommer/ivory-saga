namespace IvorySaga.Mongo
{
    public interface IMongoConnectionOptions
    {
        string Host { get; set; }

        int Port { get; set; }

        string RootPassword { get; set; }
    }
}
