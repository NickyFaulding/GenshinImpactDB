﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WadApplication.Model;

namespace WadApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210327233027_Initialdb")]
    partial class Initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WadApplication.Model.Artifact", b =>
                {
                    b.Property<int>("ArtifactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("SetName")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("ArtifactID");

                    b.ToTable("AllArtifacts");
                });

            modelBuilder.Entity("WadApplication.Model.ArtifactSet", b =>
                {
                    b.Property<string>("SetName")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("FourPieceBonus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxRarity")
                        .HasColumnType("int");

                    b.Property<int>("MinRarity")
                        .HasColumnType("int");

                    b.Property<string>("TwoPieceBonus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SetName");

                    b.ToTable("ArtifactSets");
                });

            modelBuilder.Entity("WadApplication.Model.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Nation")
                        .HasColumnType("varchar(15)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<string>("Vision")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("WeaponType")
                        .HasColumnType("varchar(10)");

                    b.HasKey("CharacterID");

                    b.ToTable("AllCharacters");
                });

            modelBuilder.Entity("WadApplication.Model.Weapon", b =>
                {
                    b.Property<int>("WeaponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Passive")
                        .HasColumnType("text");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<string>("SubStat")
                        .HasColumnType("varchar(35)");

                    b.Property<decimal>("SubStatValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("WeaponID");

                    b.ToTable("AllWeapons");
                });
#pragma warning restore 612, 618
        }
    }
}
