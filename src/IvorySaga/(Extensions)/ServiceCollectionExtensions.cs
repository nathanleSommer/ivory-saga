using System.Reflection;
using IvorySaga.Mongo;
using IvorySaga.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIvorySaga(this IServiceCollection services, IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services
                .Configure<MongoConnectionOptions>(configuration.GetSection(nameof(MongoConnectionOptions)))
                .Configure<IvorySagaDatabaseSettings>(configuration.GetSection(nameof(IvorySagaDatabaseSettings)));

            services.AddSingleton<IMongoConnectionOptions>(sp => sp.GetRequiredService<IOptions<MongoConnectionOptions>>().Value);
            services.AddSingleton<IIvorySagaDatabaseSettings>(sp => sp.GetRequiredService<IOptions<IvorySagaDatabaseSettings>>().Value);

            services.AddSingleton<SagaRepository>();
            services.AddSingleton<ChapterRepository>();

            return services;
        }
    }
}
