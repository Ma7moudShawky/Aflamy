﻿// <auto-generated />
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
    [Migration("20220606143513_AddMovieSeedData1")]
    partial class AddMovieSeedData1
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
#pragma warning restore 612, 618
        }
    }
}
