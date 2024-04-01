namespace No1B.Services;

public static class ConfigureServices
{
    public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ISeedService, SeedService>();

        return services;
    }
}