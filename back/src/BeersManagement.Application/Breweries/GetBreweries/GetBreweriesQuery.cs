using MediatR;

namespace BeersManagement.Application.Breweries.GetBreweries;

public record GetBreweriesQuery : IRequest<GetBreweriesResponse>;