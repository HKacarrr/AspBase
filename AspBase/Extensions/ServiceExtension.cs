using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
    
    
    
    public static void AddCustomMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            var systemTextJsonOutputFormatter = config.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();
            if (systemTextJsonOutputFormatter is not null)
            {
                systemTextJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.hksoftdev.hateoas+json");
                systemTextJsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.btkakademi.apiroot+json");
            }


            var xmlOutputFormatter = config.OutputFormatters.OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();
            if (xmlOutputFormatter is not null)
            {
                xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.hksoftdev.hateoas+xml");
                xmlOutputFormatter.SupportedMediaTypes.Add("application/vnd.btkakademi.apiroot+xml");
            }
        });
    }
}