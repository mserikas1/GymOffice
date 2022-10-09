using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    public partial class addAdvantage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                    table.UniqueConstraint("AK_Advantages_Title", x => x.Title);
                    table.ForeignKey(
                        name: "FK_Advantages_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advantages_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_CreatedById",
                table: "Advantages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_ModifiedById",
                table: "Advantages",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advantages");
        }
    }
}
