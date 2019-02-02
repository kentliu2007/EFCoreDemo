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

            modelBuilder.Entity<ClientAccountBalance>(entity =>
            {
                entity.Property<int>("ClientID").HasColumnName("ClientID").ValueGeneratedNever();
                entity.HasKey("ClientID");
                entity.ToTable("ClientAccountBalance");

                entity.Property("_amount").HasColumnName("Amount");

                entity.Property<int>("CurrencyID").HasColumnName("CurrencyID").ValueGeneratedNever();

                entity.HasOne(d => d.Client)
                    .WithOne(p =>  p.AccountBalance)
                    .HasForeignKey<ClientAccountBalance>("ClientID")
                    .HasConstraintName("FK_ClientAccountBalance_Clients");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.ClientAccountBalances)
                    .HasForeignKey("CurrencyID")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAccountBalance_Currencies");
            });
            modelBuilder.Entity<ClientAccountBalance>().Ignore(e => e.Amount);


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