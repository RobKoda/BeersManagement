using BeersManagement.BlazorApp.Domain.Breweries;

namespace BeersManagement.BlazorApp.Application.Breweries.GetBreweries;

public record GetBreweriesResponse(IEnumerable<Brewery> Breweries);