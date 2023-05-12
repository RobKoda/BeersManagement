using Microsoft.EntityFrameworkCore;

namespace BeersManagement.Infrastructure.Tests.Core;

public class DataBuilder<TDbContext> where TDbContext : DbContext
{
    private const string ConnectionString =
        "Server=VAULTINATOR; Database=beers-unittests-database;Integrated Security=SSPI;TrustServerCertificate=True";

    private DataBuilder(TDbContext inContext)
    {
        Context = inContext;
    }

    public TDbContext Context { get; }

    public async Task CommitAsync()
    {
        await Context.SaveChangesAsync();
        ClearTracking();
    }

    public void ClearTracking() => Context.ChangeTracker.Clear(); 
    
    public static DataBuilder<TDbContext> Build() => new(CreateContext());

    public DataBuilder<TDbContext> WithEntity<T>(T inEntity)
        where T : class
    {
        Context.Add(inEntity);
        return this;
    }

    public DataBuilder<TDbContext> WithEntities<T>(IEnumerable<T> inEntities)
        where T : class =>
        inEntities.Aggregate(this, (inCurrent, inEntity) => inCurrent.WithEntity(inEntity));
    
    private static TDbContext CreateContext()
    {
        var theOptions = new DbContextOptionsBuilder<TDbContext>()
            .UseSqlServer(ConnectionString)
            .EnableSensitiveDataLogging()
            .Options;
        var theContext = (TDbContext) Activator.CreateInstance(typeof(TDbContext), theOptions)!;
        theContext.Database.EnsureCreated();
        return theContext;
    }
}