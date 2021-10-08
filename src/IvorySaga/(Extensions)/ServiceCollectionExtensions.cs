﻿using IvorySaga.Mongo;
using IvorySaga.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIvorySaga(this IServiceCollection services, IConfiguration configuration)
        {
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Configure<IvorySagaDatabaseSettings>(
                configuration.GetSection(nameof(IvorySagaDatabaseSettings)));

            services.AddSingleton<IIvorySagaDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<IvorySagaDatabaseSettings>>().Value);

            services.AddSingleton<SagaRepository>();
            services.AddSingleton<ChapterRepository>();

            return services;
        }
    }
}
