using BeersManagement.Application.Breweries.Persistence;
using BeersManagement.Infrastructure.Breweries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeersManagement.Infrastructure;

public static class ServicesRegistration
{
    public static void RegisterInfrastructure(this IServiceCollection inServices, IConfiguration inConfiguration)
    {
        inServices.AddDbContext<ApplicationContext>(inOptions =>
        {
            inOptions.UseSqlServer(inConfiguration.GetConnectionString("DefaultConnection"));
#if DEBUG
            inOptions.EnableSensitiveDataLogging();
#endif
        });

        inServices.AddScoped<IBreweriesRepository, BreweriesRepository>();
    }
}