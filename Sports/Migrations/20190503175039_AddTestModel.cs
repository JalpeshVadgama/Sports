using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sports.Migrations
{
    public partial class AddTestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfTest = table.Column<int>(nullable: false),
                    TestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    descritpion = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "TestType",
                columns: new[] { "id", "descritpion", "name" },
                values: new object[] { 1, "Cooper Test", "Coopertest" });

            migrationBuilder.InsertData(
                table: "TestType",
                columns: new[] { "id", "descritpion", "name" },
                values: new object[] { 2, "100 Meter Sprint", "HundredMeterSprint" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "TestType");
        }
    }
}
