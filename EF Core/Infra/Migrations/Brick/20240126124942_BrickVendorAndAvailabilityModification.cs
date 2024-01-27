using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations.Brick
{
    public partial class BrickVendorAndAvailabilityModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrickAvailabilities",
                table: "BrickAvailabilities",
                newName: "AvailableAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "BrickAvailabilities",
                type: "decimal(8 , 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableAmount",
                table: "BrickAvailabilities",
                newName: "BrickAvailabilities");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "BrickAvailabilities",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8 , 2)");
        }
    }
}
