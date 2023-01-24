using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.idPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Birhtdate).IsRequired();
                p.HasData(
                    new Patient { idPatient = 1, FirstName = "Jan", LastName = "Kowalski", Birhtdate = DateTime.Parse("2000-01-01") },
                    new Patient { idPatient = 2, FirstName = "Michał", LastName = "Nowak", Birhtdate = DateTime.Parse("2001-02-01") }

            );

                //  modelBuilder
            });
            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.idDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);
                d.HasData(
                  new Doctor { idDoctor = 1, FirstName = "Janek", LastName = "Lekarz", Email="niewiem@gmail.com" },
                  new Doctor { idDoctor = 2, FirstName = "Michał", LastName = "Nowak", Email="takiEmail@gmail.com" }

          );

                //  modelBuilder
            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdDoctor);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();
                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);
                p.HasData(
                    new Prescription { IdPrescription =1,Date = DateTime.Parse("2022-01-01"), DueDate = DateTime.Parse("2021-02-19"),IdDoctor=1,IdPatient=2},
               new Prescription{ IdPrescription =2,Date = DateTime.Parse("2021-05-01"), DueDate = DateTime.Parse("2023-12-19"),IdDoctor=2,IdPatient=1});

                //  modelBuilder
            });

            modelBuilder.Entity<PrescriptionMedicament>(pm =>
            {
                pm.HasKey(e => e.idMedicament);
                pm.HasKey(e => e.IdPrescription);
                pm.Property(e => e.Dose).IsRequired().HasMaxLength(100);
                pm.Property(e => e.Details).IsRequired().HasMaxLength(100);
                pm.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.idMedicament);
                pm.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription);
            });
            modelBuilder.Entity<Medicament>(p =>
            {
                p.HasKey(e => e.IdMedicament);
                p.Property(e => e.Name).IsRequired().HasMaxLength(100);
                p.Property(e => e.Description).IsRequired().HasMaxLength(100);
                p.Property(e => e.Type).IsRequired().HasMaxLength(100);
             //   p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
               // p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

            });
        }

        internal object Find(int idDoctor)
        {
            throw new NotImplementedException();
        }
    }
}
