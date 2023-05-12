using System.ComponentModel.DataAnnotations.Schema;

namespace BeersManagement.Infrastructure.Breweries;

[Table("Brewery", Schema = "beers")]
public sealed class BreweryDataModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}