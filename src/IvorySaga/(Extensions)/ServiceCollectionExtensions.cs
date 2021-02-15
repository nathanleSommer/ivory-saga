using IvorySaga.Mongo;
using IvorySaga.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIvorySaga(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Configure<IvorySagaDatabaseSettings>(
                configuration.GetSection(nameof(IvorySagaDatabaseSettings)));

            services.AddSingleton<IIvorySagaDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<IvorySagaDatabaseSettings>>().Value);

            services.AddSingleton<SagaService>();

            return services;
        }
    }
}
