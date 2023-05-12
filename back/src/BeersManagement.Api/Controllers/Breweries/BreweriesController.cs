using BeersManagement.Application.Breweries.GetBreweries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeersManagement.Api.Controllers.Breweries;

[ApiController]
[Route("api/[controller]")]
public class BreweriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BreweriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetBreweriesAsync() =>
        Ok(await _mediator.Send(new GetBreweriesQuery()));
}