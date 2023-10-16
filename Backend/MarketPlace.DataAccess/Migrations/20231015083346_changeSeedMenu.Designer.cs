﻿// <auto-generated />
using System;
using MarketPlace.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketPlace.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231015083346_changeSeedMenu")]
    partial class changeSeedMenu
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3179),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            Name = "Admin MarketPlace",
                            ShortName = "AMP",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanentKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanentKey = "SystemManagement",
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3992),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "system",
                            IsDeleted = false,
                            Name = "SystemManagement",
                            OrderNumber = 1,
                            ParentId = 0,
                            Path = "/",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 2,
                            CompanentKey = "CreateCompany",
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3995),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "shop",
                            IsDeleted = false,
                            Name = "CreateCompany",
                            OrderNumber = 1,
                            ParentId = 1,
                            Path = "/createCompany",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 3,
                            CompanentKey = "CreateUser",
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3998),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "user",
                            IsDeleted = false,
                            Name = "CreateUser",
                            OrderNumber = 2,
                            ParentId = 1,
                            Path = "/createUser",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3548),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsAdmin = false,
                            IsDeleted = false,
                            Name = "Super Yönetici",
                            NameEn = "Super Admin",
                            RoleType = 0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("SelectedLanguage")
                        .HasColumnType("integer");

                    b.Property<int>("SelectedShop")
                        .HasColumnType("integer");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 10, 15, 1, 33, 46, 679, DateTimeKind.Local).AddTicks(3789),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Email = "admin@admin.com",
                            Gender = 3,
                            IsDeleted = false,
                            Name = "Admin",
                            Password = "Password1.",
                            Phone = "",
                            RoleId = 1,
                            SelectedLanguage = 1,
                            SelectedShop = 0,
                            SurName = "Admin",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.User", b =>
                {
                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");

                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
