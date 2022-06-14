﻿// <auto-generated />
using System;
using Aflamy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aflamy.Migrations
{
    [DbContext(typeof(AppDBContext))]
<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
    [Migration("20220613132346_AddCustomIdentityUserWithFavourits")]
    partial class AddCustomIdentityUserWithFavourits
========
    [Migration("20220613112044_Change-User-Role-PK")]
    partial class ChangeUserRolePK
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Aflamy.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Fantasy"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Mystery"
                        });
                });

<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
            modelBuilder.Entity("Aflamy.Models.CustomIdentityUser", b =>
========
            modelBuilder.Entity("Aflamy.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            Description = "Will's soon-to-be ex-wife mysteriously vanishes ",
                            MovieName = "Last Seen Alive",
                            Poster = "JustTest"
                        },
                        new
                        {
                            MovieID = 2,
                            Description = "One Army captain",
                            MovieName = "Interceptor",
                            Poster = "Another Test"
                        },
                        new
                        {
                            MovieID = 3,
                            Description = "The Dreamseller Desccccc",
                            MovieName = "The Dreamseller",
                            Poster = "Another Test"
                        },
                        new
                        {
                            MovieID = 4,
                            Description = "AmericanEastDDDDDDD",
                            MovieName = "AmericanEast",
                            Poster = "Another Test"
                        },
                        new
                        {
                            MovieID = 5,
                            Description = "Frank McKluskyTDs",
                            MovieName = "Frank McKlusky",
                            Poster = "Another Test"
                        });
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.Property<int>("MovieCategriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("MovieCategriesCategoryId", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "2e867ad3-fa94-4a6b-b9bd-dfc7f6608bb6",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "8c698c69-ef15-4888-b444-7cee0eb029af",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
========
                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("MovieID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
            modelBuilder.Entity("Aflamy.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.Property<int>("MovieCategriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieID")
                        .HasColumnType("int");

                    b.HasKey("MovieCategriesCategoryId", "MoviesMovieID");

                    b.HasIndex("MoviesMovieID");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "ffa04ad1-6291-477d-8cad-b88692b81e87",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "3b303566-4f93-460a-9728-73e8adcf74bf",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
========
            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

========
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Aflamy.Models.CustomIdentityUser", b =>
                {
                    b.HasOne("Aflamy.Models.Movie", null)
                        .WithMany("UsersWhoFavorite")
                        .HasForeignKey("MovieID");
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.HasOne("Aflamy.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("MovieCategriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aflamy.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
                    b.HasOne("Aflamy.Models.CustomIdentityUser", null)
========
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
                    b.HasOne("Aflamy.Models.CustomIdentityUser", null)
========
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
                    b.HasOne("Aflamy.Models.CustomIdentityUser", null)
========
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
<<<<<<<< HEAD:Aflamy/Migrations/20220613132346_AddCustomIdentityUserWithFavourits.Designer.cs
                    b.HasOne("Aflamy.Models.CustomIdentityUser", null)
========
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser<int>", null)
>>>>>>>> 44742955ff51193725736dc378884b865d87e7a1:Aflamy/Migrations/20220613112044_Change-User-Role-PK.Designer.cs
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aflamy.Models.Movie", b =>
                {
                    b.Navigation("UsersWhoFavorite");
                });
#pragma warning restore 612, 618
        }
    }
}
