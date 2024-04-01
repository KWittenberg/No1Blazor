namespace No1B.Repositories;

public static class ConfigureRepositories
{
    public static IServiceCollection AddConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}