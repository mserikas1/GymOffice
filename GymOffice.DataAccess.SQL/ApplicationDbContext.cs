using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.DataAccess.SQL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<AbonnementType> AbonnementTypes { get; set; }
        public DbSet<JobSchedule> JobSchedules { get; set; }
        public DbSet<PersonalTraining> PersonalTrainings { get; set; }
        public DbSet<TrainingVisit> TrainingVisits { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VisitorCard> VisitorCards { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public ApplicationDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GymDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Abonnement>(AbonnementConfigure);
            builder.Entity<AbonnementType>(AbonnementTypeConfigure);
            builder.Entity<JobSchedule>(JobScheduleConfigure);
            builder.Entity<PersonalTraining>(PersonalTrainingConfigure);
            builder.Entity<Visitor>(VisitorConfigure);
            builder.Entity<GroupTraining>(GroupTrainingConfigure);
            builder.Entity<Employee>(EmployeeConfigure);
            builder.Entity<Coach>(CoachConfigure);
            builder.Entity<TrainingVisit>(TrainingVisitConfigure);
            builder.Entity<VisitorCard>(VisitorCardConfigure);
        }
        public void AbonnementConfigure(EntityTypeBuilder<Abonnement> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.IssueTime).HasColumnType("datetime");
            builder.Property(a => a.ActivationTime).HasColumnType("datetime");
            builder.HasOne(a=>a.Visitor).WithMany(c => c.Abonnements).OnDelete(DeleteBehavior.Cascade); 
            builder.HasOne(a=>a.AbonnementType).WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey("TypeId");
            builder.Property(a => a.SoldPice).HasColumnType("decimal").HasPrecision(2);
        }
        public void VisitorCardConfigure(EntityTypeBuilder<VisitorCard> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.RegistrationDate).HasColumnType("datetime");
        }
        public void VisitorConfigure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.FirstName).HasColumnType("nvarchar");
            builder.Property(a => a.LastName).HasColumnType("nvarchar");
            builder.Property(a => a.PhoneNumber).HasColumnType("nvarchar");
            builder.HasOne(a => a.VisitorCard).WithOne(c => c.Visitor).HasForeignKey<VisitorCard>(c=>c.VisitorId);
        }
        public void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.PhoneNumber).HasColumnType("nvarchar");
            builder.Property(a => a.FirstName).HasColumnType("nvarchar");
            builder.Property(a => a.LastName).HasColumnType("nvarchar");
            builder.Property(a => a.PassportNumber).HasColumnType("nvarchar");
        }
        public void CoachConfigure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.PhoneNumber).HasColumnType("nvarchar");
            builder.Property(a => a.FirstName).HasColumnType("nvarchar");
            builder.Property(a => a.LastName).HasColumnType("nvarchar");
            builder.Property(a => a.PassportNumber).HasColumnType("nvarchar");
            builder.ToTable("Coach");
        }
        public void AbonnementTypeConfigure(EntityTypeBuilder<AbonnementType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.StartVisitTime).HasColumnType("nvarchar");
            builder.Property(a => a.EndVisitTime).HasColumnType("nvarchar");
            builder.Property(a => a.Price).HasColumnType("decimal").HasPrecision(2);
            builder.Property(a => a.Description).HasColumnName("nvarchar");
            builder.Property(a => a.Duration).HasConversion<string>().HasColumnType("nvarchar");
        }
        public void PersonalTrainingConfigure(EntityTypeBuilder<PersonalTraining> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ScheduledStartDate).HasColumnType("datetime");
            builder.Property(a => a.ScheduledEndDate).HasColumnType("datetime");
            builder.Property(a => a.Description).HasColumnName("nvarchar");
            builder.HasOne(a=>a.Visitor).WithMany(c=>c.PersonalTrainings).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Coach).WithMany(c => c.PersonalTrainings).OnDelete(DeleteBehavior.Cascade);
        }
        public void JobScheduleConfigure(EntityTypeBuilder<JobSchedule> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DayOfWeek).HasConversion<string>().HasColumnType("nvarchar");
            builder.Property(a => a.StartTime).HasColumnType("nvarchar");
            builder.Property(a => a.EndTime).HasColumnType("nvarchar");
            builder.Property(a => a.SpecificDate).HasColumnType("date");
            builder.HasOne(a=>a.Coach).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Employee).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
        public void GroupTrainingConfigure(EntityTypeBuilder<GroupTraining> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DayOfWeek).HasConversion<string>().HasColumnType("nvarchar");
            builder.Property(a => a.Name).HasMaxLength(50);
            builder.Property(a => a.StartTime).HasConversion(t=>t.ToString(), t=>TimeOnly.Parse(t));
            builder.Property(a => a.EndTime).HasColumnType("nvarchar");
            builder.HasOne(a => a.Coach).WithMany(c => c.GroupTrainings).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.Visitors).WithMany(c => c.GroupTrainings).UsingEntity("GroupTrainingRecord");
        }
        public void TrainingVisitConfigure(EntityTypeBuilder<TrainingVisit> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.StartDate).HasColumnType("datetime");
            builder.Property(a => a.EndDate).HasColumnType("datetime");
            builder.HasOne(a => a.PersonalTraining).WithMany().OnDelete(DeleteBehavior.Cascade);//not cascade
            builder.HasOne(a => a.GroupTraining).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
