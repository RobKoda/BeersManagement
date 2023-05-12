using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeersManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBreweryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "beers");

            migrationBuilder.CreateTable(
                name: "Brewery",
                schema: "beers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brewery",
                schema: "beers");
        }
    }
}
