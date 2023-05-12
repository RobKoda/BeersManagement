using AutoFixture;
using BeersManagement.Application.Breweries.GetBreweries;
using BeersManagement.Application.Breweries.Persistence;
using BeersManagement.Domain.Breweries;
using FluentAssertions;
using Moq;

namespace BeersManagement.Application.Tests.Breweries.GetBreweries;

public sealed class GetBreweriesHandlerTests
{
    private readonly Mock<IBreweriesRepository> _breweriesRepository;
    private readonly IFixture _fixture;
    private readonly GetBreweriesHandler _getBreweriesHandler;

    public GetBreweriesHandlerTests()
    {
        _breweriesRepository = new Mock<IBreweriesRepository>();
        _fixture = new Fixture();
        _getBreweriesHandler = new GetBreweriesHandler(_breweriesRepository.Object);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public async Task Handle_ShouldReturnEmployer()
    {
        // Arrange
        var theBreweries = _fixture.CreateMany<Brewery>().ToList();
        var theRequest = _fixture.Create<GetBreweriesQuery>();
        _breweriesRepository.Setup(inRepository => inRepository.GetBreweriesAsync())
            .ReturnsAsync(theBreweries);

        // Act
        var theResult = await _getBreweriesHandler.Handle(theRequest, CancellationToken.None);

        // Assert
        theResult.Breweries.Should().BeEquivalentTo(theBreweries);
    }
}