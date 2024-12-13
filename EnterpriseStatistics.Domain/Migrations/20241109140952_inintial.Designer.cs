﻿// <auto-generated />
using System;
using EnterpriseStatistics.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnterpriseStatistics.Domain.Migrations
{
    [DbContext(typeof(EnterpriseStatisticsDbContext))]
    [Migration("20241109140952_inintial")]
    partial class inintial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EnterpriseStatistics.Domain.Models.Enterprise", b =>
                {
                    b.Property<ulong>("MainStateRegistrationNumber")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("int");

                    b.Property<string>("IndustryType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OwnershipForm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalArea")
                        .HasColumnType("int");

                    b.HasKey("MainStateRegistrationNumber");

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("EnterpriseStatistics.Domain.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("EnterpriseStatistics.Domain.Models.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quanity")
                        .HasColumnType("int");

                    b.Property<ulong>("enterprise_id")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("supplier_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("enterprise_id");

                    b.HasIndex("supplier_id");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("EnterpriseStatistics.Domain.Models.Supply", b =>
                {
                    b.HasOne("EnterpriseStatistics.Domain.Models.Enterprise", "Enterprise")
                        .WithMany()
                        .HasForeignKey("enterprise_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnterpriseStatistics.Domain.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("supplier_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enterprise");

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}