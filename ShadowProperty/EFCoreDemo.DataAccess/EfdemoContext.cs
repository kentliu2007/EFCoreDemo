using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreDemo.BusinessObjects;

namespace EFCoreDemo.DataAccess
{
    public partial class EfdemoContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public EfdemoContext() : base() { }
        public EfdemoContext(DbContextOptions<EfdemoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property<int>("EmployeeID").HasColumnName("EmployeeID");
                entity.HasKey("EmployeeID");
                entity.HasIndex(e => e.EmployeeCode)
                    .HasName("idx_Employees_EmpCode")
                    .IsUnique();
            });

            OnModelCreatingExt(modelBuilder);
        }

        partial void OnModelCreatingExt(ModelBuilder modelBuilder);
    }
}