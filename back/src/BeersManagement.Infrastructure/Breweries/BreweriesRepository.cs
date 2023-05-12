using BeersManagement.Application.Breweries.Persistence;
using BeersManagement.Domain.Breweries;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BeersManagement.Infrastructure.Breweries;

public sealed class BreweriesRepository : IBreweriesRepository
{
    private readonly ApplicationContext _context;

    public BreweriesRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brewery>> GetBreweriesAsync() =>
        await _context.Breweries.AsNoTracking().ProjectToType<Brewery>().ToListAsync();
}