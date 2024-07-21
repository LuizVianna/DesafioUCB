﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UBC.Infra.Data.Context;

#nullable disable

namespace UCB.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240721165108_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UCB.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeMae")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomePai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("NotaMedia")
                        .HasColumnType("float");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(2010, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua x, nº 120 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                            Idade = 14,
                            Nome = "Luciana Souza",
                            NomeMae = "Maria de Lourdes de Souza",
                            NomePai = "Jorge Alves de Souza",
                            NotaMedia = 9.5,
                            Serie = 9
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua y, nº 230 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                            Idade = 6,
                            Nome = "Débora Soares",
                            NomeMae = "Rita Soares",
                            NomePai = "Paulo Nogueira",
                            NotaMedia = 8.5,
                            Serie = 1
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = new DateTime(2016, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Endereco = "Rua w, nº 530 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                            Idade = 7,
                            Nome = "Melissa Peixoto",
                            NomeMae = "Rose Peixoto",
                            NomePai = "Rogério Felix",
                            NotaMedia = 8.5,
                            Serie = 2
                        });
                });

            modelBuilder.Entity("UCB.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin",
                            UserName = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
