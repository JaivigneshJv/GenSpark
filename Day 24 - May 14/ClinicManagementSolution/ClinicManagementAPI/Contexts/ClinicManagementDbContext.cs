using ClinicManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ClinicManagementDbContext : DbContext
{
    public ClinicManagementDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Doctor> Doctors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor() { Id = 1, Name = "Dr. John Doe", Speciality = "Cardiology", Contact = "1234567890", Experience = 10 },
            new Doctor() { Id = 2, Name = "Dr. Jane Smith", Speciality = "Dermatology", Contact = "0987654321", Experience = 8 }
      );
    }
}