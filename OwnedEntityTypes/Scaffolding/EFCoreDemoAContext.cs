using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scaffolding
{
    public partial class EFCoreDemoAContext : DbContext
    {
        public EFCoreDemoAContext()
        {
        }

        public EFCoreDemoAContext(DbContextOptions<EFCoreDemoAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientContactInfo> ClientContactInfo { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFCoreDemoA;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<ClientContactInfo>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .ValueGeneratedNever();
                entity.Property(e => e.Email).HasColumnName("email");
                entity.HasOne(d => d.Client)
                    .WithOne(p => p.ClientContactInfo)
                    .HasForeignKey<ClientContactInfo>(d => d.ClientId);
            });
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .ForSqlServerIsClustered(false);
                entity.HasIndex(e => e.Code)
                    .HasName("idx_Clients_Code")
                    .IsUnique()
                    .ForSqlServerIsClustered();
                entity.Property(e => e.ClientId).HasColumnName("ClientID");
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
