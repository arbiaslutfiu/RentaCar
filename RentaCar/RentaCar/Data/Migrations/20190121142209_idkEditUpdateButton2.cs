using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class idkEditUpdateButton2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91d0ba03-f2a1-4cc9-9cd9-72f944126642", "AQAAAAEAACcQAAAAEIcGk7dG94E8bsH309WetIK3+mg/CSitqL7q+3+aIXve9bxEJa6PbGg+npIcpm4lLw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad7de4da-23f2-4759-8737-aaa3119b14a5", "AQAAAAEAACcQAAAAEPhTpfoWJUwkaEI7vD1Y0k2MnIjCL82fPSReRI2yeLvFP1CkFhXH4j+poWGEYAeXug==" });
        }
    }
}
