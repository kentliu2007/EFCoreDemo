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
        //public virtual DbSet<ClientAccountBalance> ClientAccountBalances { get; set; }
        //public virtual DbSet<ClientContactInfo> ClientContactInfoes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            //modelBuilder.Entity<ClientAccountBalance>(entity =>
            //{
            //    entity.HasKey(e => e.ClientID);

            //    entity.ToTable("ClientAccountBalance");

            //    entity.Property(e => e.ClientID)
            //        .HasColumnName("ClientID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CurrencyID).HasColumnName("CurrencyID");

            //    entity.HasOne(d => d.Client)
            //        .WithOne(p => p.ClientAccountBalance)
            //        .HasForeignKey<ClientAccountBalance>(d => d.ClientID)
            //        .HasConstraintName("FK_ClientAccountBalance_Clients");

            //    entity.HasOne(d => d.Currency)
            //        .WithMany(p => p.ClientAccountBalances)
            //        .HasForeignKey(d => d.CurrencyID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ClientAccountBalance_Currencies");
            //});

            modelBuilder.Entity<ClientContactInfo>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID");
                entity.HasKey("ClientID");

                entity.ToTable("ClientContactInfo");

                entity.Property(e => e.CellPhoneNo).HasMaxLength(20);

                entity.Property(e => e.MailAddress).HasMaxLength(200);

                entity.Property(e => e.TelephoneNo).HasMaxLength(20);

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.ContactInfo)
                    .HasForeignKey<ClientContactInfo>("ClientID")
                    .HasConstraintName("FK_ClientContactInfo_Clients");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property<int>("CurrencyID").HasColumnName("CurrencyID");
                entity.HasKey("CurrencyID");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired();

                entity.Property(e => e.CurrencyName)
                    .IsRequired();

                entity.Property(e => e.DecimalPlaces).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property<int>("UserID").HasColumnName("UserID");
                entity.HasKey("UserID");

                entity.HasIndex(e => e.LoginName)
                    .HasName("idx_Users_LoginName")
                    .IsUnique();


                entity.Property(e => e.LoginName)
                    .IsRequired();

                entity.Property(e => e.Password).IsRequired().HasField("_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}