﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileReviewsProject.Data;

#nullable disable

namespace MobileReviewsProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240409091354_AddingCommentTable")]
    partial class AddingCommentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MobileReviewsProject.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vivo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Techno"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Oppo"
                        });
                });

            modelBuilder.Entity("MobileReviewsProject.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("UserComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("MobileReviewsProject.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Audio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bluetooth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Browser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuiltIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Card")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dimensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiveGBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FourGBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Front")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Games")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Main")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Messaging")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatinSystem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceInPKR")
                        .HasColumnType("float");

                    b.Property<double>("PriceInUSD")
                        .HasColumnType("float");

                    b.Property<string>("Protection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sensors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technology")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThreeGBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Torch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwoGBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserInterface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.Property<string>("WLAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            ImageUrl = "\\Images\\SamsungGalaxyS24Ultra-s.jpg",
                            Model = "S24",
                            PriceInPKR = 150000.0,
                            PriceInUSD = 1500.0,
                            View = 0
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            ImageUrl = "\\Images\\Iphone.jpg",
                            Model = "Iphone14ProMax",
                            PriceInPKR = 120000.0,
                            PriceInUSD = 1200.0,
                            View = 0
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            ImageUrl = "\\Images\\VivoV30-s.jpg",
                            Model = "V30",
                            PriceInPKR = 11000.0,
                            PriceInUSD = 1100.0,
                            View = 0
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            ImageUrl = "\\Images\\TechnoSpark20256GB.jpg",
                            Model = "Spark20",
                            PriceInPKR = 90000.0,
                            PriceInUSD = 600.0,
                            View = 0
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 5,
                            ImageUrl = "\\Images\\OppoReno11-s.jpg",
                            Model = "Reno11",
                            PriceInPKR = 11000.0,
                            PriceInUSD = 1100.0,
                            View = 0
                        });
                });

            modelBuilder.Entity("MobileReviewsProject.Models.Comment", b =>
                {
                    b.HasOne("MobileReviewsProject.Models.Device", "Device")
                        .WithMany("Comments")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("MobileReviewsProject.Models.Device", b =>
                {
                    b.HasOne("MobileReviewsProject.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("MobileReviewsProject.Models.Device", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}