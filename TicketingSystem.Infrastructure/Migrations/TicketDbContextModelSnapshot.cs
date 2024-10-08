﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketingSystem.Infrastructure;

#nullable disable

namespace TicketingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(TicketDbContext))]
    partial class TicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketingSystem.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Handled")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TicketColor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketingSystem.Domain.Entities.Ticket", b =>
                {
                    b.OwnsOne("TicketingSystem.Domain.ValueObjects.City", "City", b1 =>
                        {
                            b1.Property<int>("TicketId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CityName");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("TicketingSystem.Domain.ValueObjects.District", "District", b1 =>
                        {
                            b1.Property<int>("TicketId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("DistrictName");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("TicketingSystem.Domain.ValueObjects.Governorate", "Governorate", b1 =>
                        {
                            b1.Property<int>("TicketId")
                                .HasColumnType("int");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("GovernorateName");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.Navigation("City")
                        .IsRequired();

                    b.Navigation("District")
                        .IsRequired();

                    b.Navigation("Governorate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
