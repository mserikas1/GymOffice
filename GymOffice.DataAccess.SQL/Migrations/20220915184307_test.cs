using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbonnementTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartVisitTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndVisitTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(2)", precision: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonnementTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonnementTypes_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbonnementTypes_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAtWork = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coaches_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Coaches_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAtWork = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionist_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receptionist_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receptionist_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitorCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorCards_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxVisitorsNumber = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "JobSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceptionistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfMonth = table.Column<int>(type: "int", nullable: true),
                    SpecificDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSchedules_Admin_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSchedules_Admin_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Admin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSchedules_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSchedules_Receptionist_ReceptionistId",
                        column: x => x.ReceptionistId,
                        principalTable: "Receptionist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnements_AbonnementTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AbonnementTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Abonnements_Employees_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Abonnements_VisitorCards_VisitorCardId",
                        column: x => x.VisitorCardId,
                        principalTable: "VisitorCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInGym = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitorCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_VisitorCards_VisitorCardId",
                        column: x => x.VisitorCardId,
                        principalTable: "VisitorCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainingRecord",
                columns: table => new
                {
                    GroupTrainingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainingRecord", x => new { x.GroupTrainingsId, x.VisitorsId });
                    table.ForeignKey(
                        name: "FK_GroupTrainingRecord_GroupTrainings_GroupTrainingsId",
                        column: x => x.GroupTrainingsId,
                        principalTable: "GroupTrainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupTrainingRecord_Visitors_VisitorsId",
                        column: x => x.VisitorsId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByReceptionistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByReceptionistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByCoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedByCoachId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Coaches_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Coaches_CreatedByCoachId",
                        column: x => x.CreatedByCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Coaches_ModifiedByCoachId",
                        column: x => x.ModifiedByCoachId,
                        principalTable: "Coaches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Receptionist_CreatedByReceptionistId",
                        column: x => x.CreatedByReceptionistId,
                        principalTable: "Receptionist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Receptionist_ModifiedByReceptionistId",
                        column: x => x.ModifiedByReceptionistId,
                        principalTable: "Receptionist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbonnementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalTrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupTrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingVisits_Abonnements_AbonnementId",
                        column: x => x.AbonnementId,
                        principalTable: "Abonnements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingVisits_GroupTrainings_GroupTrainingId",
                        column: x => x.GroupTrainingId,
                        principalTable: "GroupTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingVisits_PersonalTrainings_PersonalTrainingId",
                        column: x => x.PersonalTrainingId,
                        principalTable: "PersonalTrainings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingVisits_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_CreatedById",
                table: "Abonnements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_TypeId",
                table: "Abonnements",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_VisitorCardId",
                table: "Abonnements",
                column: "VisitorCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonnementTypes_CreatedById",
                table: "AbonnementTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbonnementTypes_ModifiedById",
                table: "AbonnementTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CreatedById",
                table: "Coaches",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ModifiedById",
                table: "Coaches",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainingRecord_VisitorsId",
                table: "GroupTrainingRecord",
                column: "VisitorsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_CoachId",
                table: "GroupTrainings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_CreatedById",
                table: "GroupTrainings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTrainings_ModifiedById",
                table: "GroupTrainings",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_CoachId",
                table: "JobSchedules",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_CreatedById",
                table: "JobSchedules",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_ModifiedById",
                table: "JobSchedules",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobSchedules_ReceptionistId",
                table: "JobSchedules",
                column: "ReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_CoachId",
                table: "PersonalTrainings",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_CreatedByCoachId",
                table: "PersonalTrainings",
                column: "CreatedByCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_CreatedByReceptionistId",
                table: "PersonalTrainings",
                column: "CreatedByReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_ModifiedByCoachId",
                table: "PersonalTrainings",
                column: "ModifiedByCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_ModifiedByReceptionistId",
                table: "PersonalTrainings",
                column: "ModifiedByReceptionistId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_VisitorId",
                table: "PersonalTrainings",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_CreatedById",
                table: "Receptionist",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_ModifiedById",
                table: "Receptionist",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVisits_AbonnementId",
                table: "TrainingVisits",
                column: "AbonnementId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVisits_GroupTrainingId",
                table: "TrainingVisits",
                column: "GroupTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVisits_PersonalTrainingId",
                table: "TrainingVisits",
                column: "PersonalTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVisits_VisitorId",
                table: "TrainingVisits",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorCards_CreatedById",
                table: "VisitorCards",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_VisitorCardId",
                table: "Visitors",
                column: "VisitorCardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTrainingRecord");

            migrationBuilder.DropTable(
                name: "JobSchedules");

            migrationBuilder.DropTable(
                name: "TrainingVisits");

            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "PersonalTrainings");

            migrationBuilder.DropTable(
                name: "AbonnementTypes");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "VisitorCards");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
