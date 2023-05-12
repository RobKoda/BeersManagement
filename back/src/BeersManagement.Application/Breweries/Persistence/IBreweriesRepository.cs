using BeersManagement.Domain.Breweries;

namespace BeersManagement.Application.Breweries.Persistence;

public interface IBreweriesRepository
{
    Task<IEnumerable<Brewery>> GetBreweriesAsync();
}