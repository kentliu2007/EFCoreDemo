using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TableSplitting.BusinessEntities;

namespace TableSplitting.DataAccess
{
    public partial class TableSplittingContext : DbContext
    {
        public TableSplittingContext()
        {
        }

        public TableSplittingContext(DbContextOptions<TableSplittingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFCoreDemoA;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID");
                entity.ToTable("Clients").HasKey("ClientID");
                entity.HasIndex(e => e.Code).HasName("idx_Clients_Code").IsUnique();
                entity.Property(e => e.Code).IsRequired();
                entity.Property(e => e.Name).IsRequired();
            });
            #region the following statement works while property "_contactInfo" is non public
            modelBuilder.Entity<Client>().OwnsOne(typeof(ClientContactInfo), "_contactInfo",
                (i) =>
                {
                    i.ToTable("ClientContactInfo");
                    i.Property("CellPhoneNo").HasColumnName("CellPhoneNo");
                    i.Property("Email").HasColumnName("email");
                    i.Property("TelePhoneNo").HasColumnName("TelePhoneNo");
                });
            #endregion
            #region the following statement ONLY works while property "_contactInfo" is public
            //modelBuilder.Entity<Client>().OwnsOne(
            //    typeof(ClientContactInfo).Name,
            //    "ContactInfo",
            //    (i) =>
            //    {
            //        i.ToTable("ClientContactInfo");
            //        i.Property("CellPhoneNo").HasColumnName("CellPhoneNo");
            //        i.Property("Email").HasColumnName("email");
            //        i.Property("TelePhoneNo").HasColumnName("TelePhoneNo");
            //    });
            #endregion
            modelBuilder.Entity<Client>().Ignore(e => e.Email).Ignore(e => e.CellPhoneNo).Ignore(e => e.TelePhoneNo);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}