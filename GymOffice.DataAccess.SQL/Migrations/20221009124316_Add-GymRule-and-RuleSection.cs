using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    public partial class AddGymRuleandRuleSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleSections_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RuleSections_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rules_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rules_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rules_RuleSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "RuleSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rules_CreatedById",
                table: "Rules",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_ModifiedById",
                table: "Rules",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rules_SectionId",
                table: "Rules",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleSections_CreatedById",
                table: "RuleSections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RuleSections_ModifiedById",
                table: "RuleSections",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "RuleSections");
        }
    }
}
