﻿// <auto-generated />
using System;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Persistence.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20201025111517_InitialTables")]
    partial class InitialTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("API.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT")
                        .HasMaxLength(16);

                    b.Property<decimal>("TotalPayment")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("IdProject")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Portion")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Quantity")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(9, 2)");

                    b.HasKey("Id");

                    b.HasIndex("IdProject");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("API.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("IdClient")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdClient");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("API.Entities.Payment", b =>
                {
                    b.HasOne("API.Entities.Project", "Project")
                        .WithMany("Payments")
                        .HasForeignKey("IdProject")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Entities.Project", b =>
                {
                    b.HasOne("API.Entities.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
