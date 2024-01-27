﻿// <auto-generated />
using Infra.LegoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Migrations.Brick
{
    [DbContext(typeof(BrickContext))]
    [Migration("20240126124942_BrickVendorAndAvailabilityModification")]
    partial class BrickVendorAndAvailabilityModification
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("BrickTag", b =>
                {
                    b.Property<int>("BricksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BricksId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("BrickTag");
                });

            modelBuilder.Entity("Infra.LegoModels.Brick", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Color")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bricks");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Brick");
                });

            modelBuilder.Entity("Infra.LegoModels.BrickAvailability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvailableAmount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrickId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8 , 2)");

                    b.Property<int>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrickId");

                    b.HasIndex("VendorId");

                    b.ToTable("BrickAvailabilities");
                });

            modelBuilder.Entity("Infra.LegoModels.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Infra.LegoModels.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Infra.LegoModels.BasePlate", b =>
                {
                    b.HasBaseType("Infra.LegoModels.Brick");

                    b.Property<int>("Length")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Width")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("BasePlate");
                });

            modelBuilder.Entity("Infra.LegoModels.MinifigHead", b =>
                {
                    b.HasBaseType("Infra.LegoModels.Brick");

                    b.Property<bool>("IsDualSided")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("MinifigHead");
                });

            modelBuilder.Entity("BrickTag", b =>
                {
                    b.HasOne("Infra.LegoModels.Brick", null)
                        .WithMany()
                        .HasForeignKey("BricksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.LegoModels.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infra.LegoModels.BrickAvailability", b =>
                {
                    b.HasOne("Infra.LegoModels.Brick", "Brick")
                        .WithMany("Availabilities")
                        .HasForeignKey("BrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infra.LegoModels.Vendor", "Vendor")
                        .WithMany("Availabilities")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brick");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Infra.LegoModels.Brick", b =>
                {
                    b.Navigation("Availabilities");
                });

            modelBuilder.Entity("Infra.LegoModels.Vendor", b =>
                {
                    b.Navigation("Availabilities");
                });
#pragma warning restore 612, 618
        }
    }
}