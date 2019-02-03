using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreDemo.BusinessEntities;

namespace EFCoreDemo.DataAccess
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

        public virtual DbSet<Client> Clients { get; set; }
        //public virtual DbSet<ClientContactInfo> ClientContactInfoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=EFDemo;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID");
                entity.HasKey("ClientID");
                entity.HasIndex(e => e.ClientCode)
                    .HasName("idx_Clients_ClientCode")
                    .IsUnique();

                entity.Property(e => e.ClientCode).IsRequired();
                entity.Property(e => e.ClientName).IsRequired();
            });
            modelBuilder.Entity<Client>().Ignore(e => e.MailAddress).Ignore(e => e.CellPhoneNo).Ignore(e => e.TelephoneNo);

            modelBuilder.Entity<ClientContactInfo>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID");
                entity.HasKey("ClientID");

                entity.ToTable("ClientContactInfo");

                entity.Property(e => e.CellPhoneNo);

                entity.Property(e => e.MailAddress);

                entity.Property(e => e.TelephoneNo);

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.ContactInfo)
                    .HasForeignKey<ClientContactInfo>("ClientID")
                    .HasConstraintName("FK_ClientContactInfo_Clients");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}