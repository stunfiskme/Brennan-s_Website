﻿// <auto-generated />
using BrennansWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrennansWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241223061611_BannedCropsFix")]
    partial class BannedCropsFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrennansWebsite.Models.BannedCrops", b =>
                {
                    b.Property<int>("bannedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bannedID"));

                    b.Property<string>("CropName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.HasKey("bannedID");

                    b.HasIndex("GardenId");

                    b.ToTable("BannedCrops");
                });

            modelBuilder.Entity("BrennansWebsite.Models.ClaimedBy", b =>
                {
                    b.Property<int>("PlotsId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("PlotsId", "Id");

                    b.HasIndex("Id");

                    b.ToTable("ClaimedBys");
                });

            modelBuilder.Entity("BrennansWebsite.Models.CropsGrowing", b =>
                {
                    b.Property<int>("PlotsId")
                        .HasColumnType("int");

                    b.Property<string>("cropName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PublicStatus")
                        .HasColumnType("bit");

                    b.HasKey("PlotsId", "cropName");

                    b.ToTable("CropsGrowing");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Gardener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gardeners");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Gardens", b =>
                {
                    b.Property<int>("GardenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GardenId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GardenName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.HasKey("GardenId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasFilter("[Id] IS NOT NULL");

                    b.ToTable("Gardens");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Plots", b =>
                {
                    b.Property<int>("PlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlotId"));

                    b.Property<int>("GardenId")
                        .HasColumnType("int");

                    b.Property<string>("PlotName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PlotId");

                    b.HasIndex("GardenId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("BrennansWebsite.Models.BannedCrops", b =>
                {
                    b.HasOne("BrennansWebsite.Models.Gardens", "Gardens")
                        .WithMany()
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gardens");
                });

            modelBuilder.Entity("BrennansWebsite.Models.ClaimedBy", b =>
                {
                    b.HasOne("BrennansWebsite.Models.Gardener", "Gardener")
                        .WithMany("ClaimedBy")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrennansWebsite.Models.Plots", "Plots")
                        .WithMany("ClaimedBy")
                        .HasForeignKey("PlotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gardener");

                    b.Navigation("Plots");
                });

            modelBuilder.Entity("BrennansWebsite.Models.CropsGrowing", b =>
                {
                    b.HasOne("BrennansWebsite.Models.Plots", "Plots")
                        .WithMany()
                        .HasForeignKey("PlotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plots");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Gardens", b =>
                {
                    b.HasOne("BrennansWebsite.Models.Gardener", "Gardener")
                        .WithOne("Garden")
                        .HasForeignKey("BrennansWebsite.Models.Gardens", "Id");

                    b.Navigation("Gardener");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Plots", b =>
                {
                    b.HasOne("BrennansWebsite.Models.Gardens", "Gardens")
                        .WithMany("Plots")
                        .HasForeignKey("GardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gardens");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Gardener", b =>
                {
                    b.Navigation("ClaimedBy");

                    b.Navigation("Garden");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Gardens", b =>
                {
                    b.Navigation("Plots");
                });

            modelBuilder.Entity("BrennansWebsite.Models.Plots", b =>
                {
                    b.Navigation("ClaimedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
