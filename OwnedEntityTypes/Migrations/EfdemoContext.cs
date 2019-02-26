using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Migrations
{
    public partial class MigrationsContext : DbContext
    {
        public MigrationsContext()
        {
        }

        public MigrationsContext(DbContextOptions<MigrationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        //public virtual DbSet<ClientContactInfo> ClientContactInfoes { get; set; }

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

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID");
                entity.ToTable("Clients").HasKey("ClientID").ForSqlServerIsClustered(false);
                entity.HasIndex(e => e.Code).HasName("idx_Clients_Code").IsUnique().ForSqlServerIsClustered();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Name).IsRequired();
            });
            #region the following statement works while property "ContactInfo" is both public or non-public
            modelBuilder.Entity<Client>().OwnsOne(typeof(ClientContactInfo), "ContactInfo",
                (i) =>
                {
                    i.ToTable("ClientContactInfo");
                    i.Property("CellPhoneNo").HasColumnName("CellPhoneNo");
                    i.Property("Email").HasColumnName("email");
                    i.Property("TelePhoneNo").HasColumnName("TelePhoneNo");
                });
            #endregion
            #region the following statement only works while property "clientContactInfo" is public
            ////modelBuilder.Entity<Client>().OwnsOne(
            ////    typeof(ClientContactInfo).Name,
            ////    "ContactInfo",
            ////    (i) =>
            ////    {
            ////        i.ToTable("ClientContactInfo");
            ////        i.Property("CellPhoneNo").HasColumnName("CellPhoneNo");
            ////        i.Property("Email").HasColumnName("email");
            ////        i.Property("TelePhoneNo").HasColumnName("TelePhoneNo");
            ////    });
            #endregion
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}