using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDC_QC.Shared.Models
{
    public partial class DIQCContext : DbContext
    {
        public DIQCContext()
        {
        }

        public DIQCContext(DbContextOptions<DIQCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAuditArticleDef> TblAuditArticleDef { get; set; } = null!;
        public virtual DbSet<TblAuditData> TblAuditData { get; set; } = null!;
        public virtual DbSet<TblAuditListsDef> TblAuditListsDef { get; set; } = null!;
        public virtual DbSet<TblAuditScenario> TblAuditScenario { get; set; } = null!;
        public virtual DbSet<TblAuditScenarioConnection> TblAuditScenarioConnection { get; set; } = null!;
        public virtual DbSet<TblAuditType> TblAuditType { get; set; } = null!;
        public virtual DbSet<TblContData> TblContData { get; set; } = null!;
        public virtual DbSet<TblContDataAttribData> TblContDataAttribData { get; set; } = null!;
        public virtual DbSet<TblContDataAttribDef> TblContDataAttribDef { get; set; } = null!;
        public virtual DbSet<TblMatlGrpDef> TblMatlGrpDef { get; set; } = null!;
        public virtual DbSet<TblProcGrp> TblProcGrp { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAuditArticleDef>(entity =>
            {
                entity.HasKey(e => e.AuditArticleDefUid);

                entity.ToTable("tblAuditArticleDef");

                entity.Property(e => e.AuditArticleDefUid).HasColumnName("AuditArticleDefUID");

                entity.Property(e => e.ContDataAttribDefUid).HasColumnName("ContDataAttribDefUID");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAuditData>(entity =>
            {
                entity.HasKey(e => e.AuditDataUid);

                entity.ToTable("tblAuditData");

                entity.Property(e => e.AuditDataUid).HasColumnName("AuditDataUID");

                entity.Property(e => e.AuditArticleDefUid).HasColumnName("AuditArticleDefUID");

                entity.Property(e => e.AuditScenarioUid).HasColumnName("AuditScenarioUID");

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuditArticleDefU)
                    .WithMany(p => p.TblAuditData)
                    .HasForeignKey(d => d.AuditArticleDefUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAuditData_tblAuditArticleDef");

                entity.HasOne(d => d.AuditScenarioU)
                    .WithMany(p => p.TblAuditData)
                    .HasForeignKey(d => d.AuditScenarioUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAuditData_tblAuditScenario");
            });

            modelBuilder.Entity<TblAuditListsDef>(entity =>
            {
                entity.HasKey(e => e.AuditListsUid);

                entity.ToTable("tblAuditListsDef");

                entity.Property(e => e.AuditListsUid).HasColumnName("AuditListsUID");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAuditScenario>(entity =>
            {
                entity.HasKey(e => e.AuditScenarioUid);

                entity.ToTable("tblAuditScenario");

                entity.Property(e => e.AuditScenarioUid).HasColumnName("AuditScenarioUID");

                entity.Property(e => e.AuditTypeUid).HasColumnName("AuditTypeUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuditTypeU)
                    .WithMany(p => p.TblAuditScenario)
                    .HasForeignKey(d => d.AuditTypeUid)
                    .HasConstraintName("FK_tblAuditScenario_tblAuditType");
            });

            modelBuilder.Entity<TblAuditScenarioConnection>(entity =>
            {
                entity.HasKey(e => e.AuditScenarioConnectionUid);

                entity.ToTable("tblAuditScenarioConnection");

                entity.Property(e => e.AuditScenarioConnectionUid).HasColumnName("AuditScenarioConnectionUID");

                entity.Property(e => e.AuditScenarioUid).HasColumnName("AuditScenarioUID");

                entity.Property(e => e.AuditTypeUid).HasColumnName("AuditTypeUID");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.MatlGrpDefUid).HasColumnName("MatlGrpDefUID");

                entity.HasOne(d => d.AuditScenarioU)
                    .WithMany(p => p.TblAuditScenarioConnection)
                    .HasForeignKey(d => d.AuditScenarioUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAuditScenarioConnection_tblAuditScenario");

                entity.HasOne(d => d.AuditTypeU)
                    .WithMany(p => p.TblAuditScenarioConnection)
                    .HasForeignKey(d => d.AuditTypeUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAuditScenarioConnection_tblAuditType");

                entity.HasOne(d => d.MatlGrpDefU)
                    .WithMany(p => p.TblAuditScenarioConnection)
                    .HasForeignKey(d => d.MatlGrpDefUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAuditScenarioConnection_tblMatlGrpDef");
            });

            modelBuilder.Entity<TblAuditType>(entity =>
            {
                entity.HasKey(e => e.AuditTypeUid);

                entity.ToTable("tblAuditType");

                entity.Property(e => e.AuditTypeUid).HasColumnName("AuditTypeUID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblContData>(entity =>
            {
                entity.HasKey(e => e.ContTranUid);

                entity.ToTable("tblContData");

                entity.Property(e => e.ContTranUid).HasColumnName("ContTranUID");

                entity.Property(e => e.AuditNum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AuditScenarioUid).HasColumnName("AuditScenarioUID");

                entity.Property(e => e.AuditTypeUid).HasColumnName("AuditTypeUID");

                entity.Property(e => e.Finish).HasColumnType("datetime");

                entity.Property(e => e.MatlGrpDefUid).HasColumnName("MatlGrpDefUID");

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.TranType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.AuditScenarioU)
                    .WithMany(p => p.TblContData)
                    .HasForeignKey(d => d.AuditScenarioUid)
                    .HasConstraintName("FK_tblContData_tblAuditScenario");

                entity.HasOne(d => d.AuditTypeU)
                    .WithMany(p => p.TblContData)
                    .HasForeignKey(d => d.AuditTypeUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContData_tblAuditType");

                entity.HasOne(d => d.MatlGrpDefU)
                    .WithMany(p => p.TblContData)
                    .HasForeignKey(d => d.MatlGrpDefUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContData_tblMatlGrpDef1");
            });

            modelBuilder.Entity<TblContDataAttribData>(entity =>
            {
                entity.HasKey(e => e.ContDataAttribDataUid);

                entity.ToTable("tblContDataAttribData");

                entity.Property(e => e.ContDataAttribDataUid).HasColumnName("ContDataAttribDataUID");

                entity.Property(e => e.ContDataAttribDefUid).HasColumnName("ContDataAttribDefUID");

                entity.Property(e => e.ContTranUid).HasColumnName("ContTranUID");

                entity.Property(e => e.RevNo)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ContDataAttribDefU)
                    .WithMany(p => p.TblContDataAttribData)
                    .HasForeignKey(d => d.ContDataAttribDefUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContDataAttribData_tblContDataAttribDef");

                entity.HasOne(d => d.ContTranU)
                    .WithMany(p => p.TblContDataAttribData)
                    .HasForeignKey(d => d.ContTranUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContDataAttribData_tblContData");
            });

            modelBuilder.Entity<TblContDataAttribDef>(entity =>
            {
                entity.HasKey(e => e.ContDataAttribDefUid);

                entity.ToTable("tblContDataAttribDef");

                entity.Property(e => e.ContDataAttribDefUid).HasColumnName("ContDataAttribDefUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMatlGrpDef>(entity =>
            {
                entity.HasKey(e => e.MatlGrpDefUid);

                entity.ToTable("tblMatlGrpDef");

                entity.Property(e => e.MatlGrpDefUid).HasColumnName("MatlGrpDefUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PosCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.ProcGrpUid).HasColumnName("ProcGrpUID");

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProcGrpU)
                    .WithMany(p => p.TblMatlGrpDef)
                    .HasForeignKey(d => d.ProcGrpUid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMatlGrpDef_tblProcGrp1");
            });

            modelBuilder.Entity<TblProcGrp>(entity =>
            {
                entity.HasKey(e => e.ProcGrpUid);

                entity.ToTable("tblProcGrp");

                entity.Property(e => e.ProcGrpUid).HasColumnName("ProcGrpUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RevDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
