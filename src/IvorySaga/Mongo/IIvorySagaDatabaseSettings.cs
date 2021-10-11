﻿namespace IvorySaga.Mongo
{
    public interface IIvorySagaDatabaseSettings
    {
        string SagasCollectionName { get; set; }

        string ChaptersCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}