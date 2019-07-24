using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class senepldh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Carsid",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Carsid",
                table: "Cars",
                column: "Carsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cars_Carsid",
                table: "Cars",
                column: "Carsid",
                principalTable: "Cars",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cars_Carsid",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Carsid",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Carsid",
                table: "Cars");
        }
    }
}
