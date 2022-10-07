using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    public partial class nullableVisitorCardId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_VisitorCards_VisitorCardId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_VisitorCardId",
                table: "Visitors");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitorCardId",
                table: "Visitors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorCardId",
                table: "Visitors",
                column: "VisitorCardId",
                unique: true,
                filter: "[VisitorCardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_VisitorCards_VisitorCardId",
                table: "Visitors",
                column: "VisitorCardId",
                principalTable: "VisitorCards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_VisitorCards_VisitorCardId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_VisitorCardId",
                table: "Visitors");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitorCardId",
                table: "Visitors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorCardId",
                table: "Visitors",
                column: "VisitorCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_VisitorCards_VisitorCardId",
                table: "Visitors",
                column: "VisitorCardId",
                principalTable: "VisitorCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
