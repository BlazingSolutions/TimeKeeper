﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeKeeper.Api.Data;

#nullable disable

namespace TimeKeeper.Api.Migrations
{
    [DbContext(typeof(TimeKeeperContext))]
    [Migration("20211013093859_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TimeKeeper.Api.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TimeKeeper.Api.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("TimeKeeper.Api.Domain.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorisedBy")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Client")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Hours")
                        .HasColumnType("decimal(18,0)");

                    b.Property<bool>("IsAuthorised")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmitted")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("Client");

                    b.ToTable("TimeEntries");
                });

            modelBuilder.Entity("TimeKeeper.Api.Domain.TimeEntry", b =>
                {
                    b.HasOne("TimeKeeper.Api.Domain.Category", "CategoryNavigation")
                        .WithMany("TimeEntries")
                        .HasForeignKey("Category")
                        .IsRequired()
                        .HasConstraintName("FK_TimeEntries_Categories");

                    b.HasOne("TimeKeeper.Api.Domain.Client", "ClientNavigation")
                        .WithMany("TimeEntries")
                        .HasForeignKey("Client")
                        .IsRequired()
                        .HasConstraintName("FK_TimeEntries_Clients");

                    b.Navigation("CategoryNavigation");

                    b.Navigation("ClientNavigation");
                });

            modelBuilder.Entity("TimeKeeper.Api.Domain.Category", b =>
                {
                    b.Navigation("TimeEntries");
                });

            modelBuilder.Entity("TimeKeeper.Api.Domain.Client", b =>
                {
                    b.Navigation("TimeEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
