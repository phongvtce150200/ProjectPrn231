using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BusinessObject
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceDetails> invoiceDetails { get; set; }
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
        public DbSet<PrescriptionDetails> prescriptionDetails { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<ReservedSchedule> reservedSchedules { get; set; }
        public DbSet<ScheduleDetails> ScheduleDetails { get; set; }
        public DbSet<Event> events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceDetails>().HasKey(ivd => new
            {
              ivd.InvoiceId,
              ivd.MedicineId
            });
            modelBuilder.Entity<PrescriptionDetails>().HasKey(pd => new
            {
              pd.PrescriptionId,
              pd.MedicineId
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new IdentityRole { Name = "Doctor", NormalizedName = "DOCTOR".ToUpper() },
                new IdentityRole { Name = "Nurse", NormalizedName = "NURSE".ToUpper() },
                new IdentityRole { Name = "Patient", NormalizedName = "PATIENT".ToUpper() });

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<User>().HasData(
                new User { UserName = "admin", FullName = "admin", Gender = Gender.Male, Birhtday = Convert.ToDateTime("01/01/1990") ,Email = "admin@clinc.com", NormalizedEmail = "ADMIN@CLINIC.COM", EmailConfirmed = true, PhoneNumber = "0909090090", PhoneNumberConfirmed = true, NormalizedUserName = "ADMIN", PasswordHash = hasher.HashPassword(null, "admin@@") },
                new User { UserName = "phongvt1712", FullName = "Võ Thanh Phong", Gender = Gender.Male, Birhtday = Convert.ToDateTime("02/01/2001") ,Email = "v.thanhphong1712@gmail.com", NormalizedEmail = "V.THANHPHONG1712@GMAIL.COM", EmailConfirmed = true, PhoneNumber = "0769339456", PhoneNumberConfirmed = true, NormalizedUserName = "PHONGVT1712", PasswordHash = hasher.HashPassword(null, "123456") },
                new User { UserName = "hauphan", FullName = "Phan Công Hậu", Gender = Gender.Male, Birhtday = Convert.ToDateTime("01/01/2001"), Email = "hauphan@gmail.com", NormalizedEmail = "HAUPHAN@GMAIL.COM", EmailConfirmed = true, PhoneNumber = "0808080080", PhoneNumberConfirmed = true, NormalizedUserName = "HAUPHAN", PasswordHash = hasher.HashPassword(null, "123456") });

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

    }
}
