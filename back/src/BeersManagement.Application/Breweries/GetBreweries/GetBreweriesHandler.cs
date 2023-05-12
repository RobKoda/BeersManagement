using BeersManagement.Application.Breweries.Persistence;
using MediatR;

namespace BeersManagement.Application.Breweries.GetBreweries;

public class GetBreweriesHandler : IRequestHandler<GetBreweriesQuery, GetBreweriesResponse>
{
    private readonly IBreweriesRepository _repository;

    public GetBreweriesHandler(IBreweriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetBreweriesResponse> Handle(GetBreweriesQuery request, CancellationToken cancellationToken) => 
        new(await _repository.GetBreweriesAsync());
}