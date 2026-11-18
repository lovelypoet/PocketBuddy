using Microsoft.Extensions.DependencyInjection;

namespace PocketBuddy.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register feature services here, for example: services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}
