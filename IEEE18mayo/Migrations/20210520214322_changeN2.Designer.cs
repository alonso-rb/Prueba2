﻿// <auto-generated />
using System;
using IEEE18mayo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IEEE18mayo.Migrations
{
    [DbContext(typeof(IEEEContext))]
    [Migration("20210520214322_changeN2")]
    partial class changeN2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

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
