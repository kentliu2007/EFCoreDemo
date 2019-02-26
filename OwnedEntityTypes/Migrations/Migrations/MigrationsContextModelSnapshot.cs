﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Migrations;

namespace Migrations.Migrations
{
    [DbContext(typeof(MigrationsContext))]
    partial class MigrationsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Migrations.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClientID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ClientID")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("idx_Clients_Code")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Migrations.Client", b =>
                {
                    b.OwnsOne("Migrations.ClientContactInfo", "ContactInfo", b1 =>
                        {
                            b1.Property<int>("ClientID");

                            b1.Property<string>("CellPhoneNo")
                                .HasColumnName("CellPhoneNo");

                            b1.Property<string>("Email")
                                .HasColumnName("email");

                            b1.Property<string>("TelePhoneNo")
                                .HasColumnName("TelePhoneNo");

                            b1.HasKey("ClientID");

                            b1.ToTable("ClientContactInfo");

                            b1.HasOne("Migrations.Client")
                                .WithOne("ContactInfo")
                                .HasForeignKey("Migrations.ClientContactInfo", "ClientID")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
