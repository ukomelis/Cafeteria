﻿// <auto-generated />
using CafeteriaAPI.Postgre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CafeteriaAPI.Migrations
{
    [DbContext(typeof(CafeteriaContext))]
    partial class CafeteriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CafeteriaAPI.Postgre.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brownie",
                            Price = 0.65m,
                            ProductTypeId = 0,
                            Stock = 48
                        },
                        new
                        {
                            Id = 2,
                            Name = "Muffin",
                            Price = 1.00m,
                            ProductTypeId = 0,
                            Stock = 36
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cake Pop",
                            Price = 1.35m,
                            ProductTypeId = 0,
                            Stock = 24
                        },
                        new
                        {
                            Id = 4,
                            Name = "Apple tart",
                            Price = 1.50m,
                            ProductTypeId = 0,
                            Stock = 60
                        },
                        new
                        {
                            Id = 5,
                            Name = "Water",
                            Price = 1.50m,
                            ProductTypeId = 0,
                            Stock = 30
                        },
                        new
                        {
                            Id = 6,
                            Name = "Shirt",
                            Price = 2.00m,
                            ProductTypeId = 1,
                            Stock = 0
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pants",
                            Price = 3.00m,
                            ProductTypeId = 1,
                            Stock = 0
                        },
                        new
                        {
                            Id = 8,
                            Name = "Jacket",
                            Price = 4.00m,
                            ProductTypeId = 1,
                            Stock = 0
                        },
                        new
                        {
                            Id = 9,
                            Name = "Toy",
                            Price = 1.00m,
                            ProductTypeId = 1,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("CafeteriaAPI.Postgre.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Other"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
