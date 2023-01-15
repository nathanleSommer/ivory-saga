namespace Microsoft.Extensions.DependencyInjection;

using IvorySaga.Application.Common.Persistence.Interfaces.Persistence;
using IvorySaga.Infrastructure.Persistence;
using IvorySaga.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IvorySagaDbContext>(
            o => o.UseNpgsql(configuration.GetConnectionString("Postgresql")));

        services.BuildServiceProvider().GetRequiredService<IvorySagaDbContext>().Database.Migrate();

        services.AddScoped<ISagaRepository, SagaRepository>();

        return services;
    }
}
