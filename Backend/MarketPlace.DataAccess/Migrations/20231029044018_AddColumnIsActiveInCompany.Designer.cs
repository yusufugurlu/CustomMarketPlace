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
    [Migration("20231029044018_AddColumnIsActiveInCompany")]
    partial class AddColumnIsActiveInCompany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adana"
                        });
                });

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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

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
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(2308),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsActive = false,
                            IsDeleted = false,
                            Name = "Admin MarketPlace",
                            ShortName = "AMP",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Adanaİlçesi"
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.IntegrationForWorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApiKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApiSecret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("IdForApi")
                        .HasColumnType("text");

                    b.Property<int>("IntegrationType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkPlaceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkPlaceId");

                    b.ToTable("IntegrationForWorkPlaces");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Menu", b =>
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

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHide")
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

                    b.Property<string>("UIName")
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
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3272),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "tool",
                            IsDeleted = false,
                            IsHide = false,
                            Name = "SystemManagement",
                            OrderNumber = 1,
                            ParentId = 0,
                            Path = "/",
                            UIName = "systemManagement",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3276),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "",
                            IsDeleted = false,
                            IsHide = false,
                            Name = "Settings",
                            OrderNumber = 1,
                            ParentId = 1,
                            Path = "/settings",
                            UIName = "settings",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3279),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "user",
                            IsDeleted = false,
                            IsHide = true,
                            Name = "AdminWorkplaces",
                            OrderNumber = 2,
                            ParentId = 2,
                            Path = "/adminWorkplaces",
                            UIName = "adminWorkplaces",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3282),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            Icon = "user",
                            IsDeleted = false,
                            IsHide = true,
                            Name = "AdminCompanies",
                            OrderNumber = 2,
                            ParentId = 2,
                            Path = "/adminCompanies",
                            UIName = "adminCompanies",
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
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(2700),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            Name = "Super Yönetici",
                            NameEn = "Super Admin",
                            RoleType = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.RoleMenu", b =>
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

                    b.Property<int>("MenuId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3859),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            MenuId = 1,
                            RoleId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3862),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            MenuId = 2,
                            RoleId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3864),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            MenuId = 3,
                            RoleId = 1,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(3866),
                            CreatedUserId = 0,
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedUserId = 0,
                            IsDeleted = false,
                            MenuId = 4,
                            RoleId = 1,
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

                    b.Property<int>("SelectedCompany")
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
                            CreatedDate = new DateTime(2023, 10, 28, 21, 40, 18, 493, DateTimeKind.Local).AddTicks(2997),
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
                            SelectedCompany = 0,
                            SelectedLanguage = 1,
                            SelectedShop = 0,
                            SurName = "Admin",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedUserId = 0
                        });
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.WorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DeletedUserId")
                        .HasColumnType("integer");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("integer");

                    b.Property<string>("VKN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.District", b =>
                {
                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.IntegrationForWorkPlace", b =>
                {
                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.WorkPlace", "WorkPlace")
                        .WithMany("IntegrationForWorkPlaces")
                        .HasForeignKey("WorkPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkPlace");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.RoleMenu", b =>
                {
                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
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

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.WorkPlace", b =>
                {
                    b.HasOne("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Company", "Company")
                        .WithMany("WorkPlaces")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Company", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("WorkPlaces");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Menu", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.Role", b =>
                {
                    b.Navigation("RoleMenus");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("MarketPlace.DataAccess.Models.CustomMarketPlaceModels.WorkPlace", b =>
                {
                    b.Navigation("IntegrationForWorkPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
