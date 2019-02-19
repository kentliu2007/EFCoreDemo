using System;
using System.Collections.Generic;
using System.Text;
using EFCoreDemoDefaultInheritance.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoDefaultInheritance.DataAccess
{
    public partial class EFCoreDemoDefaultInheritanceContext : DbContext
    {
        public EFCoreDemoDefaultInheritanceContext()
        {
        }

        public EFCoreDemoDefaultInheritanceContext(DbContextOptions<EFCoreDemoDefaultInheritanceContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFCoreDemoA;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("UserID");
                entity.HasKey("UserID");
                entity.ToTable("Users");
            });

        }
    }
}