﻿// <auto-generated />
using System;
using BelajarRESTApi.Database.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BelajarRESTApi.Database.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("integer");

                    b.Property<int>("ProductQty")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product", "dbo");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("VarChar(100)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier", "dbo");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionCode")
                        .IsRequired()
                        .HasColumnType("VarChar(10)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TransactionId");

                    b.ToTable("Transaction", "dbo");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.TransactionDetail", b =>
                {
                    b.Property<int>("TransactionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionDetailId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Qty")
                        .HasColumnType("integer");

                    b.Property<int>("SubTotal")
                        .HasColumnType("integer");

                    b.Property<int>("TransactionId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionDetail", "dbo");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Product", b =>
                {
                    b.HasOne("BelajarRESTApi.Database.Models.Supplier", "Suppliers")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.TransactionDetail", b =>
                {
                    b.HasOne("BelajarRESTApi.Database.Models.Product", "Products")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BelajarRESTApi.Database.Models.Transaction", "Transactions")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Product", b =>
                {
                    b.Navigation("TransactionDetails");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BelajarRESTApi.Database.Models.Transaction", b =>
                {
                    b.Navigation("TransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
