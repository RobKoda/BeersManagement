using BeersManagement.Application.Breweries.GetBreweries;
using Microsoft.Extensions.DependencyInjection;

namespace BeersManagement.Application;

public static class ServicesRegistration
{
    public static void RegisterApplication(this IServiceCollection inServices)
    {
        inServices.AddMediatR(inConfiguration => inConfiguration.RegisterServicesFromAssemblyContaining<GetBreweriesResponse>());
    }
}