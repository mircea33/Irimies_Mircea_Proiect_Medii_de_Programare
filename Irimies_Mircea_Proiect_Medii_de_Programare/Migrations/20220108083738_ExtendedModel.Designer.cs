﻿// <auto-generated />
using System;
using Irimies_Mircea_Proiect_Medii_de_Programare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Irimies_Mircea_Proiect_Medii_de_Programare.Migrations
{
    [DbContext(typeof(TeamContext))]
    [Migration("20220108083738_ExtendedModel")]
    partial class ExtendedModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Antrenor", b =>
                {
                    b.Property<int>("AntrenorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EchipaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_nasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AntrenorID");

                    b.HasIndex("EchipaID");

                    b.ToTable("Antrenor");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Conferinta", b =>
                {
                    b.Property<int>("ConferintaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nume_divizie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConferintaID");

                    b.ToTable("Conferinta");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Echipa", b =>
                {
                    b.Property<int>("EchipaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConferintaID")
                        .HasColumnType("int");

                    b.Property<string>("nume_echipa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EchipaID");

                    b.HasIndex("ConferintaID");

                    b.ToTable("Echipa");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Jucator", b =>
                {
                    b.Property<int>("JucatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EchipaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_nasterii")
                        .HasColumnType("datetime2");

                    b.Property<float>("greutate")
                        .HasColumnType("real");

                    b.Property<float>("inaltime")
                        .HasColumnType("real");

                    b.Property<string>("nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pozitie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JucatorID");

                    b.HasIndex("EchipaID");

                    b.ToTable("Jucator");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Antrenor", b =>
                {
                    b.HasOne("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Echipa", "echipa")
                        .WithMany("Antrenori")
                        .HasForeignKey("EchipaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("echipa");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Echipa", b =>
                {
                    b.HasOne("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Conferinta", "conferinta")
                        .WithMany("Echipe")
                        .HasForeignKey("ConferintaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conferinta");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Jucator", b =>
                {
                    b.HasOne("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Echipa", "echipa")
                        .WithMany("Jucatori")
                        .HasForeignKey("EchipaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("echipa");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Conferinta", b =>
                {
                    b.Navigation("Echipe");
                });

            modelBuilder.Entity("Irimies_Mircea_Proiect_Medii_de_Programare.Models.Echipa", b =>
                {
                    b.Navigation("Antrenori");

                    b.Navigation("Jucatori");
                });
#pragma warning restore 612, 618
        }
    }
}
