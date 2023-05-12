using BeersManagement.Infrastructure.Breweries;
using FluentAssertions;

namespace BeersManagement.Infrastructure.Tests.Breweries;

public sealed class BreweryDataModelTests
{
    [Fact]
    [Trait("Category", "Unit")]
    public void NewBreweryDataModel_ShouldInitializeEmptyStrings()
    {
        // Act
        var theBreweryDataModel = new BreweryDataModel();

        // Assert
        theBreweryDataModel.Name.Should().BeEmpty();
    }
}