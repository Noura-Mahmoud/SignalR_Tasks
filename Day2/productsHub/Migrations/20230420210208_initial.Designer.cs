﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using productsHub.Models;

#nullable disable

namespace productsHub.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230420210208_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("productsHub.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Text = "This is a comment for product 1",
                            UserName = "User1"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Text = "This is a comment for product 2",
                            UserName = "User2"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 1,
                            Text = "This is a comment for product 1",
                            UserName = "User3"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 3,
                            Text = "This is a comment for product 3",
                            UserName = "User4"
                        });
                });

            modelBuilder.Entity("productsHub.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is the first product",
                            Name = "Product 1",
                            Price = 10,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is the second product",
                            Name = "Product 2",
                            Price = 20,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is the third product",
                            Name = "Product 3",
                            Price = 30,
                            Quantity = 15
                        });
                });

            modelBuilder.Entity("productsHub.Models.Comment", b =>
                {
                    b.HasOne("productsHub.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
