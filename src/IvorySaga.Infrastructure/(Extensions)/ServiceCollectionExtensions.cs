using IvorySaga.Application.Common.Persistence.Interfaces;
using IvorySaga.Infrastructure.Persistence;
using IvorySaga.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

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
