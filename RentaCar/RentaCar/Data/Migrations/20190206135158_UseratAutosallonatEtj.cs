using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class UseratAutosallonatEtj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AutoSallonId",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AutoSallons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    SuperAcountId = table.Column<string>(nullable: true),
                    AdminAcountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoSallons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoSallons_AspNetUsers_AdminAcountId",
                        column: x => x.AdminAcountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoSallons_AspNetUsers_SuperAcountId",
                        column: x => x.SuperAcountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AutoSallonId",
                table: "Cars",
                column: "AutoSallonId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoSallons_AdminAcountId",
                table: "AutoSallons",
                column: "AdminAcountId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoSallons_SuperAcountId",
                table: "AutoSallons",
                column: "SuperAcountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AutoSallons_AutoSallonId",
                table: "Cars",
                column: "AutoSallonId",
                principalTable: "AutoSallons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AutoSallons_AutoSallonId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "AutoSallons");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AutoSallonId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "AutoSallonId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "9c81d4f2-a3d1-4238-a624-cd4c0ba862a4", "admin@test.com", true, false, null, "superadmin@aka.com", "superadmin@aka.com", "AQAAAAEAACcQAAAAEDexSb28itxKl7ZzG8pxhBXzJ8/fvU7Y+vFW9Th//md7q/cPZfdTrU6rhSHCQ13Zgw==", null, false, "", false, "superadmin@aka.com" });
        }
    }
}
