using System.Text;
using Entities.Models.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Presentation.ActionFilters.Validation;
using Repositories;
using Repositories.Config;
using Repositories.Config.Context;
using Repositories.Models.Auth;
using Repositories.Models.Category;
using Repositories.Models.Product;
using Services.Auth;
using Services.Auth.Profile;
using Services.Category;
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
        serviceCollection.AddScoped<CategoryRepository>();
        serviceCollection.AddScoped<UserRepository>();
        serviceCollection.AddScoped<ProfileRepository>();
        
        // Interface mappings for services
        serviceCollection.AddScoped<IBaseRepository<User>, UserRepository>();
        serviceCollection.AddScoped<IBaseRepository<Entities.Models.Auth.Profile>, ProfileRepository>();
        serviceCollection.AddScoped<IBaseRepository<Profile>, ProfileRepository>();
    }


    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ServiceManager>();
    }

    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ProductService, ProductService>();
        serviceCollection.AddScoped<CategoryService, CategoryService>();
        serviceCollection.AddScoped<AuthenticationService, AuthenticationService>();
        serviceCollection.AddScoped<ProfileService, ProfileService>();
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


    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(opts =>
            {
                /** Password Requireds */
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequiredLength = 6;


                /** User Requireds */
                opts.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }


    public static void ConfigureActionFilters(this IServiceCollection services)
    {
        services.AddScoped<ValidationFilterAttribute>();
    }


    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secretKey"]))
            };
        });
    }
}