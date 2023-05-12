using AutoFixture;
using BeersManagement.Api.Controllers.Breweries;
using BeersManagement.Application.Breweries.GetBreweries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BeersManagement.Api.Tests.Controllers.Breweries;

public sealed class BreweriesControllerTests
{
    private readonly BreweriesController _breweriesController;
    private readonly IFixture _fixture;
    private readonly Mock<IMediator> _mockMediator;

    public BreweriesControllerTests()
    {
        _fixture = new Fixture();
        _mockMediator = new Mock<IMediator>();
        _breweriesController = new BreweriesController(_mockMediator.Object);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task GetBreweriesAsync_ShouldReturnOkResponseWithBreweries()
    {
        // Arrange
        var theResponse = _fixture.Create<GetBreweriesResponse>();
        _mockMediator
            .Setup(inMediator => inMediator.Send(It.IsAny<GetBreweriesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(theResponse);

        // Act
        var theResult = await _breweriesController.GetBreweriesAsync();

        // Assert
        theResult.Should().BeOfType<OkObjectResult>();
        var theOkResult = (theResult as OkObjectResult)!;
        theOkResult.Value.Should().Be(theResponse);
    }
}