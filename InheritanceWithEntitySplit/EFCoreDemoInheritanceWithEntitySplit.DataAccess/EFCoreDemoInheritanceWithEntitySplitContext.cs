using System;
using System.Collections.Generic;
using System.Text;
using EFCoreDemoInheritanceWithEntitySplit.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoInheritanceWithEntitySplit.DataAccess
{
    public partial class EFCoreDemoInheritanceWithEntitySplitContext : DbContext
    {
        public EFCoreDemoInheritanceWithEntitySplitContext()
        {
        }

        public EFCoreDemoInheritanceWithEntitySplitContext(DbContextOptions<EFCoreDemoInheritanceWithEntitySplitContext> options)
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

            });
            modelBuilder.Entity<Student>().Ignore("StudentCode").Ignore("GradeLevel");
            modelBuilder.Entity<Teacher>().Ignore("StaffCode").Ignore("SalaryGrade");

            modelBuilder.Entity<InternalStudent>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("StudentID").ValueGeneratedNever();
                entity.HasKey("UserID");
                entity.ToTable("Students");
                entity.HasIndex(e => e.StudentCode).HasName("idx_Students_StudentCode").IsUnique();
                entity.Property(e => e.StudentCode).IsRequired();
                entity.Property(e => e.GradeLevel).IsRequired();
                entity.HasOne(d => d.Student).WithOne("internalStudent").HasForeignKey<InternalStudent>("UserID").HasConstraintName("FK_Students_Users");
            });

            modelBuilder.Entity<InternalTeacher>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("TeacherID").ValueGeneratedNever();
                entity.HasKey("UserID");
                entity.ToTable("Teachers");
                entity.HasIndex(e => e.StaffCode).HasName("idx_Teachers_StaffCode").IsUnique();
                entity.Property(e => e.StaffCode).IsRequired();
                entity.Property(e => e.SalaryGrade).IsRequired();
                entity.HasOne(d => d.Teacher).WithOne("internalTeacher").HasForeignKey<InternalTeacher>("UserID").HasConstraintName("FK_Teachers_Users");
            });

        }
    }
}
