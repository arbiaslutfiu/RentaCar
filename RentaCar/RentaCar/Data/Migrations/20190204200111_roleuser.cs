using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class roleuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "760c5370-76c6-4056-a9de-2cacfa4541ed", "AQAAAAEAACcQAAAAECBy/OgAUwJVmfTwJ/3hCoNfz2v1Ozq56ftUN2yZb108jkSa0dTtwxtELaKUexXwiQ==" });
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
