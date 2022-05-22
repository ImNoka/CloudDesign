﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerEntityDataWCF.Model;

namespace ServerEntityDataWCF.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20220521165219_ChangedNameCloud")]
    partial class ChangedNameCloud
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServerEntityDataWCF.Model.ArchiveFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("UserCloudId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserCloudId");

                    b.ToTable("ArchiveFiles");
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.ArchiveFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Path")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserCloudId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserCloudId");

                    b.ToTable("ArchiveFolders");
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserCloudId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCloudId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.UserCloud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsersClouds");
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.ArchiveFile", b =>
                {
                    b.HasOne("ServerEntityDataWCF.Model.ArchiveFolder", "ParentFolder")
                        .WithMany("Files")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerEntityDataWCF.Model.UserCloud", "UserCloud")
                        .WithMany("ArchiveFiles")
                        .HasForeignKey("UserCloudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.ArchiveFolder", b =>
                {
                    b.HasOne("ServerEntityDataWCF.Model.ArchiveFolder", "ParentFolder")
                        .WithMany("Folders")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServerEntityDataWCF.Model.UserCloud", "UserCloud")
                        .WithMany("ArchiveFolders")
                        .HasForeignKey("UserCloudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServerEntityDataWCF.Model.User", b =>
                {
                    b.HasOne("ServerEntityDataWCF.Model.UserCloud", "UserCloud")
                        .WithOne("User")
                        .HasForeignKey("ServerEntityDataWCF.Model.User", "UserCloudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
