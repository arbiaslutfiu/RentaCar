using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class carImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c81d4f2-a3d1-4238-a624-cd4c0ba862a4", "AQAAAAEAACcQAAAAEDexSb28itxKl7ZzG8pxhBXzJ8/fvU7Y+vFW9Th//md7q/cPZfdTrU6rhSHCQ13Zgw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe6178a6-0657-4978-b732-e801d6101ff3", "AQAAAAEAACcQAAAAEB3KH6U9qj59qWEdnpzoDu1inGxB7YOZAVWG0HEwJ8OgdWvUe7GP/zV1XeGhMYit4g==" });
        }
    }
}
