using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe6178a6-0657-4978-b732-e801d6101ff3", "AQAAAAEAACcQAAAAEB3KH6U9qj59qWEdnpzoDu1inGxB7YOZAVWG0HEwJ8OgdWvUe7GP/zV1XeGhMYit4g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91d0ba03-f2a1-4cc9-9cd9-72f944126642", "AQAAAAEAACcQAAAAEIcGk7dG94E8bsH309WetIK3+mg/CSitqL7q+3+aIXve9bxEJa6PbGg+npIcpm4lLw==" });
        }
    }
}
