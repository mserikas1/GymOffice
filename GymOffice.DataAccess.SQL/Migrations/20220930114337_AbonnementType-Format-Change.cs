using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    public partial class AbonnementTypeFormatChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AbonnementTypes",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "AbonnementTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "AbonnementTypes",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "AbonnementTypes",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
