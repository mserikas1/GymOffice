namespace GymOffice.DataAccess.SQL
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Abonnement> Abonnements { get; set; } = null!;
        public DbSet<AbonnementType> AbonnementTypes { get; set; } = null!;
        public DbSet<JobSchedule> JobSchedules { get; set; } = null!;
        public DbSet<PersonalTraining> PersonalTrainings { get; set; } = null!;
        public DbSet<TrainingVisit> TrainingVisits { get; set; } = null!;
        public DbSet<GroupTraining> GroupTrainings { get; set; } = null!;
        public DbSet<Visitor> Visitors { get; set; } = null!;
        public DbSet<Coach> Coaches { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<VisitorCard> VisitorCards { get; set; } = null!;
        public DbSet<Receptionist> Receptionists { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Abonnement>(AbonnementConfigure);
            builder.Entity<Visitor>(VisitorConfigure);
            builder.Entity<Receptionist>(ReceptionistConfigure);
            builder.Entity<Admin>(AdminConfigure);
            builder.Entity<AbonnementType>(AbonnementTypeConfigure);
            builder.Entity<JobSchedule>(JobScheduleConfigure);
            builder.Entity<PersonalTraining>(PersonalTrainingConfigure);
            builder.Entity<GroupTraining>(GroupTrainingConfigure);
            builder.Entity<Employee>(EmployeeConfigure);
            builder.Entity<Coach>(CoachConfigure);
            builder.Entity<TrainingVisit>(TrainingVisitConfigure);
            builder.Entity<VisitorCard>(VisitorCardConfigure);

        }
        public void AbonnementConfigure(EntityTypeBuilder<Abonnement> builder)
        {
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.AbonnementType).WithMany(a=>a.Abonnements).OnDelete(DeleteBehavior.NoAction).HasForeignKey("TypeId");
            builder.HasMany(a => a.TrainingVisits).WithOne(a => a.Abonnement).OnDelete(DeleteBehavior.NoAction);
            builder.Property(a => a.SoldPrice).HasColumnType("decimal").HasPrecision(10, 2);
        }
        public void VisitorCardConfigure(EntityTypeBuilder<VisitorCard> builder)
        {
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.Abonnements).WithOne(a => a.VisitorCard).OnDelete(DeleteBehavior.NoAction);
        }
        public void VisitorConfigure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasOne(a => a.VisitorCard).WithOne(c => c.Visitor).HasForeignKey<Visitor>(c => c.VisitorCardId);
            builder.HasMany(a => a.PersonalTrainings).WithOne(t => t.Visitor);
            builder.HasMany(a => a.TrainingVisits).WithOne();
            
        }
        public void EmployeeConfigure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasAlternateKey(a => a.PhoneNumber);
            builder.HasAlternateKey(a => a.Email);
            builder.HasAlternateKey(a => a.PassportNumber);
        }
        public void CoachConfigure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasMany(a => a.PersonalTrainings).WithOne(t => t.Coach);
            builder.HasMany(a => a.JobScheduleItems).WithOne(i => i.Coach);
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasAlternateKey(a => a.PhoneNumber);
            builder.HasAlternateKey(a => a.Email);
            builder.HasAlternateKey(a => a.PassportNumber);
        }
        public void ReceptionistConfigure(EntityTypeBuilder<Receptionist> builder)
        {
            builder.ToTable("Receptionist");
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(a => a.JobScheduleItems).WithOne(i => i.Receptionist).OnDelete(DeleteBehavior.NoAction);
        }
        public void AdminConfigure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");
        }
        public void AbonnementTypeConfigure(EntityTypeBuilder<AbonnementType> builder)
        {
            builder.Property(a => a.Price).HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(a => a.Duration).HasConversion<int>();
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
        public void PersonalTrainingConfigure(EntityTypeBuilder<PersonalTraining> builder)
        {
            builder.HasOne(a => a.CreatedByCoach).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedByCoach).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.CreatedByReceptionist).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedByReceptionist).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
        public void JobScheduleConfigure(EntityTypeBuilder<JobSchedule> builder)
        {
            builder.Property(a => a.DayOfWeek).HasConversion<string>().HasColumnType("nvarchar");
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
        public void GroupTrainingConfigure(EntityTypeBuilder<GroupTraining> builder)
        {
            builder.Property(a => a.DayOfWeek).HasConversion<string>().HasColumnType("nvarchar");
            builder.HasOne(a => a.Coach).WithMany(c => c.GroupTrainings).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(a => a.Visitors).WithMany(c => c.GroupTrainings).UsingEntity("GroupTrainingRecord");
            builder.HasOne(a => a.CreatedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(a => a.ModifiedBy).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
        public void TrainingVisitConfigure(EntityTypeBuilder<TrainingVisit> builder)
        {
            builder.HasOne(a => a.PersonalTraining).WithMany().OnDelete(DeleteBehavior.NoAction);//not cascade
            builder.HasOne(a => a.GroupTraining).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
