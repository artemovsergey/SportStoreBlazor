using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace SportStore.Application;

public static class ApplicationServicesRegistration
{
    // Extension method for IServiceCollection
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add logging services
        services.AddLogging();

        // Add MediatR services and register services from the current assembly
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(
               Assembly.GetExecutingAssembly()));

        return services;
    }
}
