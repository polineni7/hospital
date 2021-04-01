using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class hospitalsContext : DbContext
    {
        public hospitalsContext()
        {
        }

        public hospitalsContext(DbContextOptions<hospitalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consultations> Consultations { get; set; }
        public virtual DbSet<Dispensary> Dispensary { get; set; }
        public virtual DbSet<Labs> Labs { get; set; }
        public virtual DbSet<PatientAdmissions> PatientAdmissions { get; set; }
        public virtual DbSet<PatientRegistrations> PatientRegistrations { get; set; }
        public virtual DbSet<Receipts> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=RAJATHEGREAT\\SQLEXPRESS;Database=hospitals;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultations>(entity =>
            {
                entity.HasKey(e => e.ConsultationId)
                    .HasName("PK__Consulta__1B7DAECB935E3D02");

                entity.Property(e => e.ConsultationId).HasColumnName("consultationId");

                entity.Property(e => e.ConsultationAmt).HasColumnName("consultationAmt");

                entity.Property(e => e.Dat)
                    .HasColumnName("dat")
                    .HasColumnType("datetime");

                entity.Property(e => e.DrName)
                    .HasColumnName("drName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatiendId).HasColumnName("patiendId");

                entity.HasOne(d => d.Patiend)
                    .WithMany(p => p.Consultations)
                    .HasForeignKey(d => d.PatiendId)
                    .HasConstraintName("FK__Consultat__patie__3B75D760");
            });

            modelBuilder.Entity<Dispensary>(entity =>
            {
                entity.HasKey(e => e.Billno)
                    .HasName("PK__dispensa__6D9AEEA111B7EB90");

                entity.ToTable("dispensary");

                entity.Property(e => e.Billno).HasColumnName("billno");

                entity.Property(e => e.BillAmt).HasColumnName("billAmt");

                entity.Property(e => e.Dat)
                    .HasColumnName("dat")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Dispensary)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__dispensar__patie__412EB0B6");
            });

            modelBuilder.Entity<Labs>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__labs__A29BFB88B707E397");

                entity.ToTable("PatientAdmissions");

                entity.Property(e => e.TestId).HasColumnName("testId");

                entity.Property(e => e.Dat)
                    .HasColumnName("dat")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabAmt).HasColumnName("labAmt");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Testname)
                    .HasColumnName("testname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Labs)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__labs__patientId__3E52440B");
            });

            modelBuilder.Entity<PatientAdmissions>(entity =>
            {
                entity.HasKey(e => e.AdminssionId)
                    .HasName("PK__patientA__77D6585AF340B544");

                entity.ToTable("patientAdmissions");

                entity.Property(e => e.AdminssionId).HasColumnName("adminssionId");

                entity.Property(e => e.ClosingDate)
                    .HasColumnName("closingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DailyAmt).HasColumnName("dailyAmt");

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joiningDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.Roomno)
                    .HasColumnName("roomno")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientAdmissions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__patientAd__patie__38996AB5");
            });

            modelBuilder.Entity<PatientRegistrations>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__patientR__A17005ECC4D1E352");

                entity.ToTable("patientRegistrations");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.Addr)
                    .HasColumnName("addr")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenumber)
                    .HasColumnName("mobilenumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasColumnName("patientName")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Receipts>(entity =>
            {
                entity.HasKey(e => e.ReceiptNo)
                    .HasName("PK__receipts__CAA7A1A40FBF4A0F");

                entity.ToTable("receipts");

                entity.Property(e => e.ReceiptNo).HasColumnName("receiptNo");

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.Dat)
                    .HasColumnName("dat")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__receipts__patien__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
