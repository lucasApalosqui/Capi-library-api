﻿// <auto-generated />
using System;
using Capi_Library_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Capi_Library_Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("BookWriter", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("BookWriter");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Complement")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasDefaultValue("Nenhum")
                        .HasColumnName("Complement");

                    b.Property<string>("Disctrict")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("District");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Street");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GeneralAud")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("GeneralAud");

                    b.Property<short>("Pages")
                        .HasColumnType("SMALLINT")
                        .HasColumnName("Pages");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Sinopsis");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR(250)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Book_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("NVARCHAR(180)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Category_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phone_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GetDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("GetDate");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("ReturnDate");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Rental_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR(128)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Role_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR(200)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR(100)")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("PasswordHash");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Cpf" }, "IX_User_Cpf")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "IX_User_Email")
                        .IsUnique();

                    b.ToTable("User_Table", (string)null);
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR(128)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Writer_Table", (string)null);
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BookCategory_BookId");

                    b.HasOne("Capi_Library_Api.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BookCategory_CategoryId");
                });

            modelBuilder.Entity("BookWriter", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BookWriter_BookId");

                    b.HasOne("Capi_Library_Api.Models.Writer", null)
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_BookWriter_WriterId");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Address", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Capi_Library_Api.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Phone", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Phone");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Rental", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.Book", "RentalBook")
                        .WithOne("Rental")
                        .HasForeignKey("Capi_Library_Api.Models.Rental", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RentalBook");

                    b.HasOne("Capi_Library_Api.Models.User", "Rentaluser")
                        .WithOne("Rental")
                        .HasForeignKey("Capi_Library_Api.Models.Rental", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_RentalUser");

                    b.Navigation("RentalBook");

                    b.Navigation("Rentaluser");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.User", b =>
                {
                    b.HasOne("Capi_Library_Api.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Book", b =>
                {
                    b.Navigation("Rental");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Capi_Library_Api.Models.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Phones");

                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}
