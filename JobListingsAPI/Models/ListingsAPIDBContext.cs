using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JobListingsAPI.Models
{
    public partial class ListingsAPIDBContext : DbContext
    {
        public ListingsAPIDBContext()
        {
        }

        public ListingsAPIDBContext(DbContextOptions<ListingsAPIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionLog> ActionLogs { get; set; }
        public virtual DbSet<TblApplicant> TblApplicants { get; set; }
        public virtual DbSet<TblApplicantSkill> TblApplicantSkills { get; set; }
        public virtual DbSet<TblApplication> TblApplications { get; set; }
        public virtual DbSet<TblCompany> TblCompanies { get; set; }
        public virtual DbSet<TblErrorLog> TblErrorLogs { get; set; }
        public virtual DbSet<TblListing> TblListings { get; set; }
        public virtual DbSet<TblRequiredSkill> TblRequiredSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ListingsAPIDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ActionLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__actionLo__7839F62D7D8DD848");

                entity.ToTable("actionLogs");

                entity.Property(e => e.LogId).HasColumnName("logID");

                entity.Property(e => e.LogAction)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logAction");

                entity.Property(e => e.LogController)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("logController");

                entity.Property(e => e.LogDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("logDateTime");

                entity.Property(e => e.LogNewValue)
                    .IsUnicode(false)
                    .HasColumnName("logNewValue");

                entity.Property(e => e.LogOldValue)
                    .IsUnicode(false)
                    .HasColumnName("logOldValue");
            });

            modelBuilder.Entity<TblApplicant>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("PK__tbl_Appl__8DB304411935E998");

                entity.ToTable("tbl_Applicants");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantID");

                entity.Property(e => e.AppContactNumber).HasColumnName("appContactNumber");

                entity.Property(e => e.AppDateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("appDateCreated");

                entity.Property(e => e.AppDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("appDateModified");

                entity.Property(e => e.AppEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("appEmail");

                entity.Property(e => e.AppIdentityNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appIdentityNumber");

                entity.Property(e => e.AppLocation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("appLocation");

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appName");

                entity.Property(e => e.AppSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appSurname");

                entity.Property(e => e.AppYearsExperience).HasColumnName("appYearsExperience");
            });

            modelBuilder.Entity<TblApplicantSkill>(entity =>
            {
                entity.HasKey(e => e.AppSkillId)
                    .HasName("PK__tbl_Appl__C02F6A81F5B09AD3");

                entity.ToTable("tbl_ApplicantSkills");

                entity.Property(e => e.AppSkillId).HasColumnName("appSkillID");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantID");

                entity.Property(e => e.AsCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("asCreatedDate");

                entity.Property(e => e.AsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("asName");
            });

            modelBuilder.Entity<TblApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__tbl_Appl__79FDB1EF085BA290");

                entity.ToTable("tbl_Applications");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationID");

                entity.Property(e => e.AppDateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("appDateCreated");

                entity.Property(e => e.ApplicantId).HasColumnName("applicantID");

                entity.Property(e => e.ListingId).HasColumnName("listingID");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__tbl_comp__AD5459B025F425F7");

                entity.ToTable("tbl_company");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CompDateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("compDateCreated");

                entity.Property(e => e.CompDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("compDateModified");

                entity.Property(e => e.CompDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("compDescription");

                entity.Property(e => e.CompLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("compLocation");

                entity.Property(e => e.CompName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("compName");
            });

            modelBuilder.Entity<TblErrorLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__tbl_erro__7839F62D107C97DE");

                entity.ToTable("tbl_errorLogs");

                entity.Property(e => e.LogId).HasColumnName("logID");

                entity.Property(e => e.Controller)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("controller");

                entity.Property(e => e.ErrorDate)
                    .HasColumnType("datetime")
                    .HasColumnName("errorDate");

                entity.Property(e => e.ExceptionMessage)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("exceptionMessage");

                entity.Property(e => e.StackTrace)
                    .IsUnicode(false)
                    .HasColumnName("stackTrace");
            });

            modelBuilder.Entity<TblListing>(entity =>
            {
                entity.HasKey(e => e.ListingId)
                    .HasName("PK__tbl_List__5A0F3C797F076AFF");

                entity.ToTable("tbl_Listings");

                entity.Property(e => e.ListingId).HasColumnName("listingID");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.ListAnnualSalary)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("listAnnualSalary");

                entity.Property(e => e.ListDateListed)
                    .HasColumnType("datetime")
                    .HasColumnName("listDateListed");

                entity.Property(e => e.ListDateModified)
                    .HasColumnType("datetime")
                    .HasColumnName("listDateModified");

                entity.Property(e => e.ListMaxExperienceRequired).HasColumnName("listMaxExperienceRequired");

                entity.Property(e => e.ListMinExperienceRequired).HasColumnName("listMinExperienceRequired");

                entity.Property(e => e.ListPositionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("listPositionName");
            });

            modelBuilder.Entity<TblRequiredSkill>(entity =>
            {
                entity.HasKey(e => e.ReqSkillId)
                    .HasName("PK__tbl_Requ__20277C90B0EA7ECA");

                entity.ToTable("tbl_RequiredSkills");

                entity.Property(e => e.ReqSkillId).HasColumnName("reqSkillID");

                entity.Property(e => e.ListingId).HasColumnName("listingID");

                entity.Property(e => e.RsCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("rsCreatedDate");

                entity.Property(e => e.RsName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rsName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
