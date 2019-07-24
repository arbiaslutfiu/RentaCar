using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class AutosalonUserCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoSallonUsers",
                columns: table => new
                {
                    AutoSallonId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoSallonUsers", x => new { x.AutoSallonId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AutoSallonUsers_AutoSallons_AutoSallonId",
                        column: x => x.AutoSallonId,
                        principalTable: "AutoSallons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoSallonUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoSallonUsers_UserId",
                table: "AutoSallonUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoSallonUsers");
        }
    }
}
