namespace Microsoft.Extensions.DependencyInjection;

using MediatR;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
