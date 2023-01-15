namespace Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIvorySaga(this IServiceCollection services, IConfiguration configuration)
    {
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
