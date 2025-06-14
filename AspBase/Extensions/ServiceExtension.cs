using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using Repositories.Config.Context;
using Repositories.Product;
using Services.Config;
using Services.Product;

namespace AspBase.Extensions;

public static class ServiceExtension
{
    public static void ConfigureSqlContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Builder services içinde çıkması için(***builder.Services.ConfigureSqlContext) this IServiceCollection serviceCollection şeklinde yazıyoruz
        serviceCollection.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }

    public static void RegisterRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<RepositoryManager>();
        serviceCollection.AddScoped<ProductRepository>();
    }


    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ServiceManager>();
    }

    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ProductService, ProductService>();
    }
}