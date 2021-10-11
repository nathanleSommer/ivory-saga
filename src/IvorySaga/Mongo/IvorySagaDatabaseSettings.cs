namespace IvorySaga.Mongo
{
    public sealed class IvorySagaDatabaseSettings : IIvorySagaDatabaseSettings
    {
        public string SagasCollectionName { get; set; } = default!;

        public string ChaptersCollectionName { get; set; } = default!;

        public string ConnectionString { get; set; } = default!;

        public string DatabaseName { get; set; } = default!;
    }
}
