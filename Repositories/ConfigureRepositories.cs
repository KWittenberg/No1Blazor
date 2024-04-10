namespace No1B.Repositories;

public static class ConfigureRepositories
{
    public static IServiceCollection AddConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IRoleRepository, RoleRepository>()
        //        .AddScoped<IUserRepository, UserRepository>()
        //        .AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        //services.AddTransient<IRepository<Category>, Repository<Category>>();

        return services;
    }
}