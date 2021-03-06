﻿// <auto-generated />
using System;
using CrvService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrvService.Data.Migrations
{
    [DbContext(typeof(CrvServiceContext))]
    partial class CrvServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrvService.Data.Entities.Buildings.Base.BuildingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CityEntityId");

                    b.ToTable("Buildings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BuildingEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Cargos.Base.CargoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BuildingEntityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Count")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BuildingEntityId");

                    b.ToTable("Cargos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CargoEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("Size")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("WorldEntityId")
                        .HasColumnType("int");

                    b.Property<float>("X")
                        .HasColumnType("float");

                    b.Property<float>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("WorldEntityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ClientCommands.Base.ClientCommandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlayerGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Processed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("WorldGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("WorldId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientCommands");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ClientCommandEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ServerCommands.Base.ServerCommandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlayerGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Processed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("WorldGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("ServerCommands");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ServerCommandEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsMoving")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("MoveToX")
                        .HasColumnType("float");

                    b.Property<float>("MoveToY")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("VisibleCitiesStr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("WorldGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("WorldId")
                        .HasColumnType("int");

                    b.Property<float>("X")
                        .HasColumnType("float");

                    b.Property<float>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("WorldId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CrvService.Data.Entities.WorldEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Guid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("WorldDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Worlds");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Buildings.LivingHouseEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Buildings.Base.BuildingEntity");

                    b.HasDiscriminator().HasValue("LivingHouseEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Buildings.SaltEvaporationFactoryEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Buildings.Base.BuildingEntity");

                    b.HasDiscriminator().HasValue("SaltEvaporationFactoryEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Cargos.FreshWaterEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Cargos.Base.CargoEntity");

                    b.HasDiscriminator().HasValue("FreshWaterEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Cargos.SaltEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Cargos.Base.CargoEntity");

                    b.HasDiscriminator().HasValue("SaltEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Cargos.SaltWaterEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Cargos.Base.CargoEntity");

                    b.HasDiscriminator().HasValue("SaltWaterEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ClientCommands.MovePlayerClientCommandEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Commands.ClientCommands.Base.ClientCommandEntity");

                    b.Property<float>("ToX")
                        .HasColumnType("float");

                    b.Property<float>("ToY")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("MovePlayerClientCommandEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ClientCommands.PingEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Commands.ClientCommands.Base.ClientCommandEntity");

                    b.HasDiscriminator().HasValue("PingEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ServerCommands.Base.EnterCityServerCommandEntity", b =>
                {
                    b.HasBaseType("CrvService.Data.Entities.Commands.ServerCommands.Base.ServerCommandEntity");

                    b.Property<string>("CityGuid")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasDiscriminator().HasValue("EnterCityServerCommandEntity");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Buildings.Base.BuildingEntity", b =>
                {
                    b.HasOne("CrvService.Data.Entities.CityEntity", null)
                        .WithMany("BuildingCollection")
                        .HasForeignKey("CityEntityId");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Cargos.Base.CargoEntity", b =>
                {
                    b.HasOne("CrvService.Data.Entities.Buildings.Base.BuildingEntity", null)
                        .WithMany("CargoCollection")
                        .HasForeignKey("BuildingEntityId");
                });

            modelBuilder.Entity("CrvService.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("CrvService.Data.Entities.WorldEntity", null)
                        .WithMany("CityCollection")
                        .HasForeignKey("WorldEntityId");
                });

            modelBuilder.Entity("CrvService.Data.Entities.Commands.ServerCommands.Base.ServerCommandEntity", b =>
                {
                    b.HasOne("CrvService.Data.Entities.PlayerEntity", "Player")
                        .WithMany("CommandsCollection")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrvService.Data.Entities.PlayerEntity", b =>
                {
                    b.HasOne("CrvService.Data.Entities.WorldEntity", "World")
                        .WithMany("PlayerCollection")
                        .HasForeignKey("WorldId");
                });
#pragma warning restore 612, 618
        }
    }
}
