using BeersManagement.Infrastructure.Breweries;
using Microsoft.EntityFrameworkCore;

namespace BeersManagement.Infrastructure;

public sealed class ApplicationContext : DbContext
{
    public DbSet<BreweryDataModel> Breweries => Set<BreweryDataModel>();

    public ApplicationContext(DbContextOptions inOptions) : base(inOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder inModelBuilder)
    {
        base.OnModelCreating(inModelBuilder);

        foreach (var theRelationship in inModelBuilder.Model.GetEntityTypes()
                     .SelectMany(inMutableEntityType => inMutableEntityType.GetForeignKeys()))
        {
            theRelationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        foreach (var theProperty in inModelBuilder.Model.GetEntityTypes()
                     .SelectMany(inMutableEntityType => inMutableEntityType.GetProperties())
                     .Where(inMutableProperty => inMutableProperty.ClrType == typeof(decimal) || inMutableProperty.ClrType == typeof(decimal?)))
        {
            theProperty.SetPrecision(18);
            theProperty.SetScale(2);
        }
    }
}