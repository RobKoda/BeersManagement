using Microsoft.AspNetCore.Mvc;

namespace BeersManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthcheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}