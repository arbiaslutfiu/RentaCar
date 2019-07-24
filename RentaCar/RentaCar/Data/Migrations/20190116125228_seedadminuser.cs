using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class seedadminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "b8775673-8e32-4d41-b6a3-2a1b8849a393", "IdentityUser", "admin@test.com", true, false, null, "superadmin@aka.com", "superadmin@aka.com", "AQAAAAEAACcQAAAAEKsYnwoOhEHPWwRO0STFlCDhUb/PKyjDVY3il2ORrvNdRaNDXe6uAB2vUIsTCz0BFw==", null, false, "", false, "superadmin@aka.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "b8775673-8e32-4d41-b6a3-2a1b8849a393" });
        }
    }
}
