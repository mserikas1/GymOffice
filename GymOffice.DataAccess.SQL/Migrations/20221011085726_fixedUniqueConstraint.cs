using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.WebAdmin.Migrations
{
    public partial class fixedUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_Email",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_PassportNumber",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_PhoneNumber",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Coaches_Email",
                table: "Coaches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Coaches_PassportNumber",
                table: "Coaches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Coaches_PhoneNumber",
                table: "Coaches");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Advantages_Title",
                table: "Advantages");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PassportNumber",
                table: "Employees",
                column: "PassportNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_Email",
                table: "Coaches",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_PassportNumber",
                table: "Coaches",
                column: "PassportNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_PhoneNumber",
                table: "Coaches",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advantages_Title",
                table: "Advantages",
                column: "Title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Email",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PassportNumber",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PhoneNumber",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_Email",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_PassportNumber",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_PhoneNumber",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Advantages_Title",
                table: "Advantages");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_Email",
                table: "Employees",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_PassportNumber",
                table: "Employees",
                column: "PassportNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_PhoneNumber",
                table: "Employees",
                column: "PhoneNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Coaches_Email",
                table: "Coaches",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Coaches_PassportNumber",
                table: "Coaches",
                column: "PassportNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Coaches_PhoneNumber",
                table: "Coaches",
                column: "PhoneNumber");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Advantages_Title",
                table: "Advantages",
                column: "Title");
        }
    }
}
