﻿// <auto-generated />
using System;
using CurrenciesTaskApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrenciesTaskApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("CurrenciesTaskApi.Data.Models.Currencies", b =>
                {
                    b.Property<int>("Cur_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Cur_Abbreviation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Abbreviation");

                    b.Property<string>("Cur_Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<string>("Cur_Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<string>("Cur_QuotName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("QuotName");

                    b.HasKey("Cur_ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("CurrenciesTaskApi.Data.Models.Currencies_Ondate", b =>
                {
                    b.Property<string>("GUID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CODE")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cur_OfficialRate")
                        .HasColumnType("TEXT")
                        .HasColumnName("CURVAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("CURDATE");

                    b.HasKey("GUID");

                    b.ToTable("Currencies_Ondates");
                });
#pragma warning restore 612, 618
        }
    }
}