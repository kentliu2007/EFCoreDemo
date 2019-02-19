using System;
using System.Collections.Generic;
using System.Text;
using EFCoreDemoDefaultInheritance.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoDefaultInheritance.DataAccess
{
    public partial class EFCoreDemoDefaultInheritanceV2Context : DbContext
    {
        public EFCoreDemoDefaultInheritanceV2Context()
        {
        }

        public EFCoreDemoDefaultInheritanceV2Context(DbContextOptions<EFCoreDemoDefaultInheritanceV2Context> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("UserID");
                entity.HasKey("UserID");
                entity.ToTable("Users");
                entity.HasIndex(e => e.LoginName).HasName("idx_Users_LoginName").IsUnique();
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.LoginName).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property<int>("UserTypeID").HasColumnName("UserTypeID");
            });
            modelBuilder.Entity<User>().Ignore("StudentCode").Ignore("GradeLevel").Ignore("StaffCode").Ignore("SalaryGrade").Ignore("TeacherID").Ignore("StudentID");
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("StudentID").ValueGeneratedNever();
                entity.ToTable("Students");
                entity.HasIndex(e => e.StudentCode).HasName("idx_Students_StudentCode").IsUnique();
                entity.Property(e => e.StudentCode).IsRequired();
                entity.Property(e => e.GradeLevel).IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("TeacherID").ValueGeneratedNever();
                entity.ToTable("Teachers");
                entity.HasIndex(e => e.StaffCode).HasName("idx_Teachers_StaffCode").IsUnique();
                entity.Property(e => e.StaffCode).IsRequired();
                entity.Property(e => e.SalaryGrade).IsRequired();
            });

        }
    }
}
