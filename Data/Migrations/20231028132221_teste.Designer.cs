﻿// <auto-generated />
using System;
using Interdisciplinar2023.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Interdisciplinar2023.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231028132221_teste")]
    partial class teste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Interdisciplinar2023.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Corridor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a96ae17a-d2e4-40b4-97dc-bdb1eb2c6d9b"),
                            Batch = "L52231T",
                            Category = 0,
                            Corridor = "B",
                            CreatedAt = new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(5483),
                            Description = "Arroz Branco Tipo 1",
                            Name = "Arroz Branco Camil",
                            ProviderId = new Guid("0234fd0e-189e-4bb4-a652-e605b563bec8"),
                            Quantity = 20,
                            Shelf = "4",
                            UpdatedAt = new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(5487),
                            Validity = new DateTime(2024, 3, 25, 11, 50, 56, 0, DateTimeKind.Utc),
                            Value = 20.0m
                        });
                });

            modelBuilder.Entity("Interdisciplinar2023.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Celphone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Providers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0234fd0e-189e-4bb4-a652-e605b563bec8"),
                            Celphone = "11933333333",
                            City = "Barra Bonita",
                            CorporateName = "Camil Alimentos LTDA",
                            CreatedAt = new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(4722),
                            Document = "64.904.295/0001-03",
                            Email = "alimentos@camil.com.br",
                            Neighborhood = "Area Rural",
                            Phone = "1133333333",
                            PostalCode = "1234567788",
                            State = "São Paulo",
                            Street = "Fazenda Pau D'Alho, s/n",
                            UpdatedAt = new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(4743)
                        });
                });

            modelBuilder.Entity("Interdisciplinar2023.Models.Product", b =>
                {
                    b.HasOne("Interdisciplinar2023.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });
#pragma warning restore 612, 618
        }
    }
}
