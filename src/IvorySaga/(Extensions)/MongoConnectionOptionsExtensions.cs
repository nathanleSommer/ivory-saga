using System;
using IvorySaga.Mongo;

namespace IvorySaga
{
    public static class MongoConnectionOptionsExtensions
    {
        public static string GetConnectionString(this IMongoConnectionOptions mongoOptions)
        {
            mongoOptions = mongoOptions ?? throw new ArgumentNullException(nameof(mongoOptions));

            var connectionString = !string.IsNullOrWhiteSpace(mongoOptions.RootPassword)
                ? $"mongodb://root:{mongoOptions.RootPassword}@{mongoOptions.Host}:{mongoOptions.Port}"
                : $"mongodb://{mongoOptions.Host}:{mongoOptions.Port}";

            return connectionString;
        }
    }
}
