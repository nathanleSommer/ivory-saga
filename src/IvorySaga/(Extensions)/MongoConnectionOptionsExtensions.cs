using System;
using IvorySaga.Mongo;

namespace IvorySaga
{
    public static class MongoConnectionOptionsExtensions
    {
        public static string GetConnectionString(this IMongoConnectionOptions mongoOptions)
        {
            mongoOptions = mongoOptions ?? throw new ArgumentNullException(nameof(mongoOptions));

            var connectionString = !string.IsNullOrWhiteSpace(mongoOptions.Username)
                ? $"mongodb://{mongoOptions.Username}:{mongoOptions.Password}@{mongoOptions.Host}:{mongoOptions.Port}"
                : $"mongodb://{mongoOptions.Host}:{mongoOptions.Port}";

            return connectionString;
        }
    }
}
