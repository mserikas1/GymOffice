using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOffice.DataAccess.SQL
{
    internal class ApplicationDbContext:IdentityDbContext
    {
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<AbonnementType> AbonnementTypes { get; set; }
        public DbSet<JobSchedule> JobSchedules { get; set; }
        public DbSet<PersonalTraining> Trainings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Abonnement>(AbonnementConfigure);
            builder.Entity<AbonnementType>(AbonnementTypeConfigure);
            builder.Entity<JobSchedule>(JobScheduleConfigure);
            builder.Entity<PersonalTraining>(PersonalTrainingConfigure);
            builder.Entity<Customer>(CustomerConfigure);
            builder.Entity<GroupTraining>(GroupTraining);
        }
        public void AbonnementConfigure(EntityTypeBuilder<Abonnement> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.IssueTime).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.ActivationTime).HasColumnType("datetime");
            builder.HasOne(a=>a.Customer).WithMany(c => c.Abonnements).OnDelete(DeleteBehavior.Cascade); 
            builder.HasOne(a=>a.AbonnementType).WithMany().OnDelete(DeleteBehavior.SetNull).HasForeignKey("TypeId");
            builder.Property(a => a.Duration).HasConversion<string>().HasColumnType("nvarchar");
        }
        public void CustomerConfigure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(a => a.Id);
        }
        public void AbonnementTypeConfigure(EntityTypeBuilder<AbonnementType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.StartVisitTime).HasColumnType("time");
            builder.Property(a => a.EndVisitTime).HasColumnType("time");
            builder.Property(a => a.PriceForMonth).HasColumnType("decimal").HasPrecision(2).IsRequired();
            builder.Property(a => a.Description).HasColumnName("nvarchar").IsRequired();
        }
        public void PersonalTrainingConfigure(EntityTypeBuilder<PersonalTraining> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ScheduledStartDate).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.ScheduledEndDate).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.StartDate).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.EndDate).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.Description).HasColumnName("nvarchar");
            builder.HasOne(a=>a.Customer).WithMany(c=>c.PersonalTrainings).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Coach).WithMany(c => c.PersonalTrainings).OnDelete(DeleteBehavior.Cascade);
        }
        public void JobScheduleConfigure(EntityTypeBuilder<JobSchedule> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DayOfWeek).HasConversion<string>().HasColumnType("nvarchar");
            builder.Property(a => a.StartTime).HasColumnType("time").IsRequired();
            builder.Property(a => a.EndTime).HasColumnType("time").IsRequired();
            builder.Property(a => a.SpecificDate).HasColumnType("datetime");
            builder.HasOne(a=>a.Coach).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Employee).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
        public void GroupTraining(EntityTypeBuilder<GroupTraining> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
            builder.Property(a => a.StartTime).HasColumnType("time");
            builder.Property(a => a.EndTime).HasColumnType("time");
            builder.HasOne(a => a.Coach).WithMany(c => c.GroupTrainings).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.Customers).WithMany(c => c.GroupTrainings).UsingEntity("GroupTrainingRecord");
        }
    }
}
