using Microsoft.EntityFrameworkCore;
using Repositories.Config.Context;

namespace AspBase.Extensions;

public static class ServiceExtension
{
    public static void ConfigureSqlContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        // Builder services içinde çıkması için(***builder.Services.ConfigureSqlContext) this IServiceCollection serviceCollection şeklinde yazıyoruz
        serviceCollection.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));
    }
}