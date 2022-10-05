﻿// <auto-generated />
using System;
using GymOffice.DataAccess.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymOffice.DataAccess.SQL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221005201928_nullableVisitorCardId")]
    partial class nullableVisitorCardId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GroupTrainingRecord", b =>
                {
                    b.Property<Guid>("GroupTrainingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitorsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupTrainingsId", "VisitorsId");

                    b.HasIndex("VisitorsId");

                    b.ToTable("GroupTrainingRecord");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Abonnement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActivationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SoldPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitorCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("TypeId");

                    b.HasIndex("VisitorCardId");

                    b.ToTable("Abonnements");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.AbonnementType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("EndVisitTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("StartVisitTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("AbonnementTypes");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAtWork")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("PassportNumber");

                    b.HasAlternateKey("PhoneNumber");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasAlternateKey("PassportNumber");

                    b.HasAlternateKey("PhoneNumber");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.GroupTraining", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxVisitorsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("GroupTrainings");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.JobSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DayOfMonth")
                        .HasColumnType("int");

                    b.Property<string>("DayOfWeek")
                        .HasColumnType("nvarchar");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReceptionistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("SpecificDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("ReceptionistId");

                    b.ToTable("JobSchedules");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.PersonalTraining", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedByCoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedByReceptionistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedByCoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ModifiedByReceptionistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ScheduledEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledStartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("CreatedByCoachId");

                    b.HasIndex("CreatedByReceptionistId");

                    b.HasIndex("ModifiedByCoachId");

                    b.HasIndex("ModifiedByReceptionistId");

                    b.HasIndex("VisitorId");

                    b.ToTable("PersonalTrainings");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.TrainingVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AbonnementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GroupTrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonalTrainingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VisitorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AbonnementId");

                    b.HasIndex("GroupTrainingId");

                    b.HasIndex("PersonalTrainingId");

                    b.HasIndex("VisitorId");

                    b.ToTable("TrainingVisits");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Visitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInGym")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VisitorCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VisitorCardId")
                        .IsUnique()
                        .HasFilter("[VisitorCardId] IS NOT NULL");

                    b.ToTable("Visitors");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.VisitorCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("VisitorCards");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Admin", b =>
                {
                    b.HasBaseType("GymOffice.Common.DTOs.Employee");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Receptionist", b =>
                {
                    b.HasBaseType("GymOffice.Common.DTOs.Employee");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAtWork")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.ToTable("Receptionist", (string)null);
                });

            modelBuilder.Entity("GroupTrainingRecord", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.GroupTraining", null)
                        .WithMany()
                        .HasForeignKey("GroupTrainingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Visitor", null)
                        .WithMany()
                        .HasForeignKey("VisitorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Abonnement", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Employee", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.AbonnementType", "AbonnementType")
                        .WithMany("Abonnements")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.VisitorCard", "VisitorCard")
                        .WithMany("Abonnements")
                        .HasForeignKey("VisitorCardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AbonnementType");

                    b.Navigation("CreatedBy");

                    b.Navigation("VisitorCard");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.AbonnementType", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Coach", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.GroupTraining", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Coach", "Coach")
                        .WithMany("GroupTrainings")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.JobSchedule", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Coach", "Coach")
                        .WithMany("JobScheduleItems")
                        .HasForeignKey("CoachId");

                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Receptionist", "Receptionist")
                        .WithMany("JobScheduleItems")
                        .HasForeignKey("ReceptionistId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Coach");

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.PersonalTraining", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Coach", "Coach")
                        .WithMany("PersonalTrainings")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Coach", "CreatedByCoach")
                        .WithMany()
                        .HasForeignKey("CreatedByCoachId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.Receptionist", "CreatedByReceptionist")
                        .WithMany()
                        .HasForeignKey("CreatedByReceptionistId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.Coach", "ModifiedByCoach")
                        .WithMany()
                        .HasForeignKey("ModifiedByCoachId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.Receptionist", "ModifiedByReceptionist")
                        .WithMany()
                        .HasForeignKey("ModifiedByReceptionistId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.Visitor", "Visitor")
                        .WithMany("PersonalTrainings")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("CreatedByCoach");

                    b.Navigation("CreatedByReceptionist");

                    b.Navigation("ModifiedByCoach");

                    b.Navigation("ModifiedByReceptionist");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.TrainingVisit", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Abonnement", "Abonnement")
                        .WithMany("TrainingVisits")
                        .HasForeignKey("AbonnementId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.GroupTraining", "GroupTraining")
                        .WithMany()
                        .HasForeignKey("GroupTrainingId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.PersonalTraining", "PersonalTraining")
                        .WithMany()
                        .HasForeignKey("PersonalTrainingId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GymOffice.Common.DTOs.Visitor", null)
                        .WithMany("TrainingVisits")
                        .HasForeignKey("VisitorId");

                    b.Navigation("Abonnement");

                    b.Navigation("GroupTraining");

                    b.Navigation("PersonalTraining");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Visitor", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.VisitorCard", "VisitorCard")
                        .WithOne("Visitor")
                        .HasForeignKey("GymOffice.Common.DTOs.Visitor", "VisitorCardId");

                    b.Navigation("VisitorCard");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.VisitorCard", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Admin", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Employee", null)
                        .WithOne()
                        .HasForeignKey("GymOffice.Common.DTOs.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Receptionist", b =>
                {
                    b.HasOne("GymOffice.Common.DTOs.Admin", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Employee", null)
                        .WithOne()
                        .HasForeignKey("GymOffice.Common.DTOs.Receptionist", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("GymOffice.Common.DTOs.Admin", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ModifiedBy");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Abonnement", b =>
                {
                    b.Navigation("TrainingVisits");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.AbonnementType", b =>
                {
                    b.Navigation("Abonnements");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Coach", b =>
                {
                    b.Navigation("GroupTrainings");

                    b.Navigation("JobScheduleItems");

                    b.Navigation("PersonalTrainings");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Visitor", b =>
                {
                    b.Navigation("PersonalTrainings");

                    b.Navigation("TrainingVisits");
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.VisitorCard", b =>
                {
                    b.Navigation("Abonnements");

                    b.Navigation("Visitor")
                        .IsRequired();
                });

            modelBuilder.Entity("GymOffice.Common.DTOs.Receptionist", b =>
                {
                    b.Navigation("JobScheduleItems");
                });
#pragma warning restore 612, 618
        }
    }
}
