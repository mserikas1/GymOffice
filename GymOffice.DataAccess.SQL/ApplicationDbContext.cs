using GymOffice.Common.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
