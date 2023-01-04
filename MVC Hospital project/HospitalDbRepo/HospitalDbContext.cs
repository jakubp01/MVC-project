
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Entities;


namespace Hospital.DbContextAndBuilders.ApiDbContext
{
    public  class HospitalDbContext : DbContext
    {
        private string _connectionstring = "Server=127.0.0.1,1433;Database=HospitalDb;User ID=sa;Password=wwsi2022S@;Encrypt=False;";

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();

            modelBuilder.Entity<Patient>()
                .Property(p => p.Name)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionstring);
        }
        
    }
}