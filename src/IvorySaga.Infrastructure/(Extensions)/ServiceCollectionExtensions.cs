namespace Microsoft.Extensions.DependencyInjection;

using IvorySaga.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPgsql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IvorySagaDataContext>(
            o => o.UseNpgsql(configuration.GetConnectionString("Postgresql")));

        services.BuildServiceProvider().GetRequiredService<IvorySagaDataContext>().Database.Migrate();

        return services;
    }
}
