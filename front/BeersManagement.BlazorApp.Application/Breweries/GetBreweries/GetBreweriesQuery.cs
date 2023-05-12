using MediatR;

namespace BeersManagement.BlazorApp.Application.Breweries.GetBreweries;

public record GetBreweriesQuery : IRequest<GetBreweriesResponse>;