using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class idkEditUpdateButton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad7de4da-23f2-4759-8737-aaa3119b14a5", "AQAAAAEAACcQAAAAEPhTpfoWJUwkaEI7vD1Y0k2MnIjCL82fPSReRI2yeLvFP1CkFhXH4j+poWGEYAeXug==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb5865cd-d020-4e87-a0a9-70c98a623a90", "AQAAAAEAACcQAAAAEEkD8M/UCLYPrb6Oj9L9+6OKBSi6saBwzjRtPbN0DvvwAtLrgxfsiDnh4bJz0HFvWA==" });
        }
    }
}
