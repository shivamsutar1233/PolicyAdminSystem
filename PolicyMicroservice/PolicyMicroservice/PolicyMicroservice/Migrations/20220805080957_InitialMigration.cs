using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyMicroservice.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuiltInPolicies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PropertyType = table.Column<string>(nullable: true),
                    ConsumerType = table.Column<string>(nullable: true),
                    AssuredSum = table.Column<int>(nullable: false),
                    Tenure = table.Column<int>(nullable: false),
                    BusinessValue = table.Column<int>(nullable: false),
                    PropertyValue = table.Column<int>(nullable: false),
                    BaseLocation = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuiltInPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false),
                    AcceptedQuotes = table.Column<string>(nullable: true),
                    PolicyStatus = table.Column<string>(nullable: true),
                    PaymentDetails = table.Column<string>(nullable: true),
                    AcceptanceStatus = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.InsertData(
                table: "BuiltInPolicies",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P01", 20000000, "Pune", 5, "Owner", "Building", 4, 3, "Replacement" });

            migrationBuilder.InsertData(
                table: "BuiltInPolicies",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P02", 40000000, "Chennai", 9, "Owner", "Factory Equipment", 8, 1, "Replacement" });

            migrationBuilder.InsertData(
                table: "BuiltInPolicies",
                columns: new[] { "Id", "AssuredSum", "BaseLocation", "BusinessValue", "ConsumerType", "PropertyType", "PropertyValue", "Tenure", "Type" },
                values: new object[] { "P03", 20000000, "Mumbai", 7, "Owner", "Property in Transit", 6, 5, "Pay Back" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuiltInPolicies");

            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
