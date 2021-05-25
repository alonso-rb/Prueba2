﻿// <auto-generated />
using System;
using IEEE18mayo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IEEE18mayo.Migrations
{
    [DbContext(typeof(IEEEContext))]
    partial class IEEEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("IEEE18mayo.Model.Curso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("IEEE18mayo.Model.Inscripción", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("cursoid")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cursoid");

                    b.HasIndex("usuarioid");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("IEEE18mayo.Model.Membresía", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("text");

                    b.Property<double>("precio")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("Membresías");
                });

            modelBuilder.Entity("IEEE18mayo.Model.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("contraseña")
                        .HasColumnType("text");

                    b.Property<int?>("membresíaid")
                        .HasColumnType("int");

                    b.Property<string>("usuario")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("membresíaid");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("IEEE18mayo.Model.Inscripción", b =>
                {
                    b.HasOne("IEEE18mayo.Model.Curso", "curso")
                        .WithMany()
                        .HasForeignKey("cursoid");

                    b.HasOne("IEEE18mayo.Model.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioid");

                    b.Navigation("curso");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("IEEE18mayo.Model.Usuario", b =>
                {
                    b.HasOne("IEEE18mayo.Model.Membresía", "membresía")
                        .WithMany()
                        .HasForeignKey("membresíaid");

                    b.Navigation("membresía");
                });
#pragma warning restore 612, 618
        }
    }
}
