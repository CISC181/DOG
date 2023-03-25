﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DOG.EF.Models;

namespace DOG.EF.Data
{
    public partial class DOGOracleContext : DbContext
    {
        public DOGOracleContext()
        {
        }

        public DOGOracleContext(DbContextOptions<DOGOracleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<DeviceCode> DeviceCodes { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Key> Keys { get; set; } = null!;
        public virtual DbSet<OraTranslateMsg> OraTranslateMsgs { get; set; } = null!;
        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DOG")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("ASP_NET_USER_ROLES");

                            j.HasIndex(new[] { "RoleId" }, "IX_ASP_NET_USER_ROLES_ROLE_ID");

                            j.IndexerProperty<string>("UserId").HasColumnName("USER_ID");

                            j.IndexerProperty<string>("RoleId").HasColumnName("ROLE_ID");
                        });
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseNo)
                    .HasName("CRSE_PK");

                entity.Property(e => e.CourseNo).ValueGeneratedNever();

                entity.HasOne(d => d.PrerequisiteNavigation)
                    .WithMany(p => p.InversePrerequisiteNavigation)
                    .HasForeignKey(d => d.Prerequisite)
                    .HasConstraintName("CRSE_CRSE_FK");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.SectionId })
                    .HasName("ENR_PK");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ENR_SECT_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ENR_STU_FK");
            });

            modelBuilder.Entity<OraTranslateMsg>(entity =>
            {
                entity.Property(e => e.OraTranslateMsgId).HasDefaultValueSql("sys_guid()");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.SectionId).ValueGeneratedNever();

                entity.HasOne(d => d.CourseNoNavigation)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SECT_CRSE_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).ValueGeneratedNever();
            });

            modelBuilder.HasSequence("COURSE_SEQ");

            modelBuilder.HasSequence("SECTION_SEQ");

            modelBuilder.HasSequence("STUDENT_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
