using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HealthcareMangementSystem.Models.DB
{
    public partial class IrelandHospitalContext : DbContext
    {
        public IrelandHospitalContext()
        {
        }

        public IrelandHospitalContext(DbContextOptions<IrelandHospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentHistory> AppointmentHistories { get; set; }
        public virtual DbSet<CovidInformation> CovidInformations { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientAddress> PatientAddresses { get; set; }
        public virtual DbSet<RehabilitationCentre> RehabilitationCentres { get; set; }
        public virtual DbSet<TblBloodDonationDetail> TblBloodDonationDetails { get; set; }
        public virtual DbSet<TblDoctor> TblDoctors { get; set; }
        public virtual DbSet<TblHospital> TblHospitals { get; set; }
        public virtual DbSet<TblLocation> TblLocations { get; set; }
        public virtual DbSet<TblOrganDonationDetail> TblOrganDonationDetails { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K9BAT38\\SQLEXPRESS;Database=IrelandHospital;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppointmentHistory>(entity =>
            {
                entity.HasKey(e => e.AppHistoryId)
                    .HasName("code_plk");

                entity.ToTable("AppointmentHistory");

                entity.Property(e => e.AppHistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppHistoryID");

                entity.Property(e => e.Appointmentdate).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.MedicalCondition)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CovidInformation>(entity =>
            {
                entity.HasKey(e => e.CovidId)
                    .HasName("code_lk");

                entity.ToTable("CovidInformation");

                entity.HasIndex(e => e.PatientId, "UQ__CovidInf__970EC3479B592817")
                    .IsUnique();

                entity.Property(e => e.CovidId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CovidID");

                entity.Property(e => e.CovidStatus)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CovidTestDate).HasColumnType("date");

                entity.Property(e => e.PatientId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PatientID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentHead)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Department_head");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.SpecialtyDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("d_code_fk");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.MedicineId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MedicineID");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("m_code_fk");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .ValueGeneratedNever()
                    .HasColumnName("PatientID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AppHistoryId).HasColumnName("AppHistoryID");

                entity.Property(e => e.CovidFlag)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("c_code_fk");

                entity.HasOne(d => d.AppHistory)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.AppHistoryId)
                    .HasConstraintName("FK_AppID");
            });

            modelBuilder.Entity<PatientAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("code_pak");

                entity.ToTable("PatientAddress");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("AddressID");

                entity.Property(e => e.AdressLine1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AdressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Eircode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EIRcode");
            });

            modelBuilder.Entity<RehabilitationCentre>(entity =>
            {
                entity.HasKey(e => e.RehabCentreId)
                    .HasName("code_rk");

                entity.ToTable("RehabilitationCentre");

                entity.Property(e => e.RehabCentreId)
                    .ValueGeneratedNever()
                    .HasColumnName("RehabCentreID");

                entity.Property(e => e.AvailabilityDetails)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CentreDetails).HasColumnType("xml");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.RehabilitationType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBloodDonationDetail>(entity =>
            {
                entity.HasKey(e => e.BloodDonationId)
                    .HasName("code_bk");

                entity.ToTable("tbl_BloodDonationDetails");

                entity.HasIndex(e => e.HospitalId, "UQ__tbl_Bloo__38C2E58E661CD963")
                    .IsUnique();

                entity.Property(e => e.BloodDonationId)
                    .ValueGeneratedNever()
                    .HasColumnName("BloodDonationID");

                entity.Property(e => e.BloodGroupDetails).HasColumnType("xml");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            });

            modelBuilder.Entity<TblDoctor>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.DepartmentId })
                    .HasName("dg_code_pk");

                entity.ToTable("tbl_Doctor");

                entity.HasIndex(e => e.HospitalId, "UQ__tbl_Doct__38C2E58EDAE16F78")
                    .IsUnique();

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EducationalDetails).HasColumnType("xml");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            });

            modelBuilder.Entity<TblHospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId)
                    .HasName("m_hosid_pk");

                entity.ToTable("tbl_Hospital");

                entity.Property(e => e.HospitalId)
                    .ValueGeneratedNever()
                    .HasColumnName("HospitalID");

                entity.Property(e => e.HasBloodDonation)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HasOrganDonation)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TblHospitals)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("c_loc_fk");
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("m_id_pk");

                entity.ToTable("tbl_location");

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("LocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eircode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EIRCode");
            });

            modelBuilder.Entity<TblOrganDonationDetail>(entity =>
            {
                entity.HasKey(e => e.OrganDonationId)
                    .HasName("code_ok");

                entity.ToTable("tbl_OrganDonationDetails");

                entity.HasIndex(e => e.HospitalDonationId, "UQ__tbl_Orga__9B54DAAD3108987E")
                    .IsUnique();

                entity.Property(e => e.OrganDonationId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrganDonationID");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalDonationId).HasColumnName("HospitalDonationID");

                entity.Property(e => e.OrganDetails).HasColumnType("xml");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.Property(e => e.VacancyId)
                    .ValueGeneratedNever()
                    .HasColumnName("VacancyID");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.JobAvailability)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.JobDetails)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("c_code_gk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
