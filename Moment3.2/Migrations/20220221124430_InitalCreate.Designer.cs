﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moment_3._2.Data;

#nullable disable

namespace Moment3._2.Migrations
{
    [DbContext(typeof(AlbumsContext))]
    [Migration("20220221124430_InitalCreate")]
    partial class InitalCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("Moment3._2.Models.Albums", b =>
                {
                    b.Property<int>("AlbumsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Rented")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumsId");

                    b.HasIndex("GenresId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Moment3._2.Models.Genres", b =>
                {
                    b.Property<int?>("GenresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("GenresId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Moment3._2.Models.Rentals", b =>
                {
                    b.Property<int>("RentalsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RentalsId");

                    b.HasIndex("AlbumsId")
                        .IsUnique();

                    b.HasIndex("UsersId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("Moment3._2.Models.Users", b =>
                {
                    b.Property<int?>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Moment3._2.Models.Albums", b =>
                {
                    b.HasOne("Moment3._2.Models.Genres", "Genres")
                        .WithMany("Albums")
                        .HasForeignKey("GenresId");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Moment3._2.Models.Rentals", b =>
                {
                    b.HasOne("Moment3._2.Models.Albums", "Albums")
                        .WithOne("RentaslId")
                        .HasForeignKey("Moment3._2.Models.Rentals", "AlbumsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moment3._2.Models.Users", "Users")
                        .WithMany("Rentals")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Albums");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Moment3._2.Models.Albums", b =>
                {
                    b.Navigation("RentaslId");
                });

            modelBuilder.Entity("Moment3._2.Models.Genres", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Moment3._2.Models.Users", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
