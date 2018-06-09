using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace HospitalApp.Models
{
    public partial class hospitalContext : DbContext
    {
        public hospitalContext()
        {
        }

        public hospitalContext(DbContextOptions<hospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Doctor>(entity =>
        //    {
        //        entity.HasKey(e => e.DoctorId);

        //        entity.HasIndex(e => e.SpecialityId)
        //            .HasName("IX_SpecialityId");

        //        entity.HasOne(d => d.Speciality)
        //            .WithMany(p => p.Doctors)
        //            .HasForeignKey(d => d.SpecialityId)
        //            .HasConstraintName("FK_dbo.Doctors_dbo.Specialities_SpecialityId");
        //    });

        //    modelBuilder.Entity<Patient>(entity =>
        //    {
        //        entity.HasKey(e => e.PatientId);
        //    });

        //    modelBuilder.Entity<Speciality>(entity =>
        //    {
        //        entity.HasKey(e => e.SpecialityId);
        //    });

        //    modelBuilder.Entity<Visit>(entity =>
        //    {
        //        entity.HasKey(e => e.Date);

        //        entity.HasIndex(e => e.DoctorId)
        //            .HasName("IX_DoctorId");

        //        entity.HasIndex(e => e.PatientId)
        //            .HasName("IX_PatientId");

        //        entity.Property(e => e.Date).HasColumnType("datetime");

        //        entity.HasOne(d => d.Doctor)
        //            .WithMany(p => p.Visits)
        //            .HasForeignKey(d => d.DoctorId)
        //            .HasConstraintName("FK_dbo.Visits_dbo.Doctors_DoctorId");

        //        entity.HasOne(d => d.Patient)
        //            .WithMany(p => p.Visits)
        //            .HasForeignKey(d => d.PatientId)
        //            .HasConstraintName("FK_dbo.Visits_dbo.Patients_PatientId");
        //    });
        //}
    }
}
