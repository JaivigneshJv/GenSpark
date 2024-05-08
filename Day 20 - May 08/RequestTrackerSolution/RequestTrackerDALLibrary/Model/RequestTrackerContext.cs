using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace RequestTrackerDALLibrary.Model
{
    public partial class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext()
        {
        }

        public RequestTrackerContext(DbContextOptions<RequestTrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                              .AddUserSecrets<RequestTrackerContext>()
                              .Build();
                var connectionString = builder.GetConnectionString("RequestTracker");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeDepartmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeDepartment)
                    .HasConstraintName("FK__Employees__Emplo__4BAC3F29");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.RaisedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestTest)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
