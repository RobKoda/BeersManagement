using System.Net.Http.Json;
using MediatR;

namespace BeersManagement.BlazorApp.Application.Breweries.GetBreweries;

public class GetBreweriesHandler : IRequestHandler<GetBreweriesQuery, GetBreweriesResponse>
{
    private readonly HttpClient _client;

    public GetBreweriesHandler(IHttpClientFactory inHttpClientFactory)
    {
        _client = inHttpClientFactory.CreateClient("BeersManagement.Api");
    }

    public async Task<GetBreweriesResponse> Handle(GetBreweriesQuery inQuery, CancellationToken inCancellationToken) =>
        await _client.GetFromJsonAsync<GetBreweriesResponse>("breweries", inCancellationToken);
}