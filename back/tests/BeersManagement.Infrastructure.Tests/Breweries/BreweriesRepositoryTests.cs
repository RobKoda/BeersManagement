using AutoFixture;
using BeersManagement.Infrastructure.Breweries;
using BeersManagement.Infrastructure.Tests.Core;
using Mapster;

namespace BeersManagement.Infrastructure.Tests.Breweries;

[Collection("Sequential")]
public class BreweriesRepositoryTests : IDisposable
{
    private readonly BreweriesRepository _breweriesRepository;
    private readonly DataBuilder<ApplicationContext> _dataBuilder;
    private readonly IFixture _fixture;

    public BreweriesRepositoryTests()
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(ServicesRegistration).Assembly);

        _fixture = new Fixture();
        _dataBuilder = DataBuilder<ApplicationContext>.Build();
        _breweriesRepository = new BreweriesRepository(_dataBuilder.Context);
    }

    public void Dispose()
    {
        _dataBuilder.Context.Database.EnsureDeleted();
        GC.SuppressFinalize(this);
    }
}