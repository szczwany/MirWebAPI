﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MirWebAPI.Data;

namespace MirWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180722213238_AddMapTypeAndMapRange")]
    partial class AddMapTypeAndMapRange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rc1-32029")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MirWebAPI.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int?>("MapRangeId");

                    b.Property<string>("Name");

                    b.Property<string>("NameKR");

                    b.HasKey("Id");

                    b.HasIndex("MapRangeId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("MirWebAPI.Models.MapRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionKR");

                    b.Property<string>("LevelRange");

                    b.Property<int>("MapTypeId");

                    b.HasKey("Id");

                    b.HasIndex("MapTypeId");

                    b.ToTable("MapRanges");
                });

            modelBuilder.Entity("MirWebAPI.Models.MapType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("NameKR");

                    b.HasKey("Id");

                    b.ToTable("MapTypes");
                });

            modelBuilder.Entity("MirWebAPI.Models.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alive");

                    b.Property<string>("Attack");

                    b.Property<string>("BC");

                    b.Property<string>("Cold");

                    b.Property<string>("Dark");

                    b.Property<string>("Defence");

                    b.Property<string>("Description");

                    b.Property<string>("Experience");

                    b.Property<string>("Fire");

                    b.Property<string>("Holy");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Items");

                    b.Property<string>("Level");

                    b.Property<string>("Light");

                    b.Property<int>("MapId");

                    b.Property<string>("Name");

                    b.Property<string>("NameKR");

                    b.Property<string>("Phantom");

                    b.Property<string>("Tame");

                    b.Property<string>("Wind");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("MirWebAPI.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("MirWebAPI.Models.Map", b =>
                {
                    b.HasOne("MirWebAPI.Models.MapRange")
                        .WithMany("Maps")
                        .HasForeignKey("MapRangeId");
                });

            modelBuilder.Entity("MirWebAPI.Models.MapRange", b =>
                {
                    b.HasOne("MirWebAPI.Models.MapType", "MapType")
                        .WithMany("MapRanges")
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MirWebAPI.Models.Monster", b =>
                {
                    b.HasOne("MirWebAPI.Models.Map", "Map")
                        .WithMany("Monsters")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
