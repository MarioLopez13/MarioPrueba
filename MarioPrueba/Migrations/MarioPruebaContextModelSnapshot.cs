﻿// <auto-generated />
using System;
using MarioPrueba.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarioPrueba.Migrations
{
    [DbContext(typeof(MarioPruebaContext))]
    partial class MarioPruebaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarioPrueba.Models.Carrera", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarreraId"));

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroSemestres")
                        .HasColumnType("int");

                    b.HasKey("CarreraId");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("MarioPrueba.Models.MLopez", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarreraId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PromedioCalificaciones")
                        .HasColumnType("real");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarreraId");

                    b.ToTable("MLopez");
                });

            modelBuilder.Entity("MarioPrueba.Models.MLopez", b =>
                {
                    b.HasOne("MarioPrueba.Models.Carrera", "carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carrera");
                });
#pragma warning restore 612, 618
        }
    }
}