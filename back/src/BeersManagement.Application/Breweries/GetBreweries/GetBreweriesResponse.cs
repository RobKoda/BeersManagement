using BeersManagement.Domain.Breweries;

namespace BeersManagement.Application.Breweries.GetBreweries;

public record GetBreweriesResponse(IEnumerable<Brewery> Breweries);