﻿// <auto-generated />
using EFCoreDemoDefaultInheritance.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreDemoDefaultInheritance.DataAccess.Migrations
{
    [DbContext(typeof(EFCoreDemoDefaultInheritanceContext))]
    partial class EFCoreDemoDefaultInheritanceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreDemoDefaultInheritance.BusinessEntities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LoginName");

                    b.Property<string>("Password");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("EFCoreDemoDefaultInheritance.BusinessEntities.Student", b =>
                {
                    b.HasBaseType("EFCoreDemoDefaultInheritance.BusinessEntities.User");

                    b.Property<int>("GradeLevel");

                    b.Property<string>("StudentCode");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("EFCoreDemoDefaultInheritance.BusinessEntities.Teacher", b =>
                {
                    b.HasBaseType("EFCoreDemoDefaultInheritance.BusinessEntities.User");

                    b.Property<int>("SalaryGrade");

                    b.Property<string>("StaffCode");

                    b.HasDiscriminator().HasValue("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
