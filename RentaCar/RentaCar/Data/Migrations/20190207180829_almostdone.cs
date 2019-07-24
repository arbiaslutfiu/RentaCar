using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class almostdone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoSallons_AspNetUsers_AdminAcountId",
                table: "AutoSallons");

            migrationBuilder.DropIndex(
                name: "IX_AutoSallons_AdminAcountId",
                table: "AutoSallons");

            migrationBuilder.DropColumn(
                name: "AdminAcountId",
                table: "AutoSallons");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "AutoSallons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminAcountId",
                table: "AutoSallons",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "AutoSallons",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_AutoSallons_AdminAcountId",
                table: "AutoSallons",
                column: "AdminAcountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoSallons_AspNetUsers_AdminAcountId",
                table: "AutoSallons",
                column: "AdminAcountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
