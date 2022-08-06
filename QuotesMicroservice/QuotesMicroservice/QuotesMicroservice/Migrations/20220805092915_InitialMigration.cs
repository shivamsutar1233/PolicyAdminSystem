using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesMicroservice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinBusinessValue = table.Column<int>(nullable: false),
                    MaxBusinessValue = table.Column<int>(nullable: false),
                    MinPropertyValue = table.Column<int>(nullable: false),
                    MaxPropertyValue = table.Column<int>(nullable: false),
                    PropertyType = table.Column<string>(nullable: true),
                    Quotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "MaxBusinessValue", "MaxPropertyValue", "MinBusinessValue", "MinPropertyValue", "PropertyType", "Quotes" },
                values: new object[,]
                {
                    { 1, 3, 3, 0, 0, "Factory Equipment", "80000" },
                    { 2, 7, 7, 4, 4, "Factory Equipment", "50000" },
                    { 3, 10, 10, 8, 8, "Factory Equipment", "30000" },
                    { 4, 3, 3, 0, 0, "Building", "80000" },
                    { 5, 7, 7, 4, 4, "Building", "50000" },
                    { 6, 10, 10, 8, 8, "Building", "30000" },
                    { 7, 3, 3, 0, 0, "Property In Transit", "80000" },
                    { 8, 7, 7, 4, 4, "Property In Transit", "50000" },
                    { 9, 10, 10, 8, 8, "Property In Transit", "30000" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
