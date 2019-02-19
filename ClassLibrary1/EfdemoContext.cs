using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1
{
    public partial class EfdemoContext : DbContext
    {
        public EfdemoContext()
        {
        }

        public EfdemoContext(DbContextOptions<EfdemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentID)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.StudentCode)
                    .HasName("idx_Students_StudentCode")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.StudentID)
                    .HasColumnName("StudentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudentCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.StudentID)
                    .HasConstraintName("FK_Students_Users");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeacherID)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.StaffCode)
                    .HasName("idx_Teachers_StaffCode")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.TeacherID)
                    .HasColumnName("TeacherID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StaffCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.TeacherNavigation)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.TeacherID)
                    .HasConstraintName("FK_Teachers_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.LoginName)
                    .HasName("idx_Users_LoginName")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.UserTypeID).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserTypes");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeID)
                    .HasColumnName("UserTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserTypeDesc).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}