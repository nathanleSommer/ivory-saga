namespace IvorySaga.Mongo
{
    public class IvorySagaDatabaseSettings : IIvorySagaDatabaseSettings
    {
        public string SagasCollectionName { get; set; } = default!;
        public string ChaptersCollectionName { get; set; } = default!;
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
    }

    public interface IIvorySagaDatabaseSettings
    {
        string SagasCollectionName { get; set; }
        string ChaptersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
