﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleSystem.Database;

#nullable disable

namespace PeopleSystem.Database.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240603183807_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PeopleSystem.Database.Models.PersonalInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PersonalInformations");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.PlaceOfResidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId")
                        .IsUnique();

                    b.ToTable("PlacesOfResidence");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.ProfilePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonalInformationId")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInformationId")
                        .IsUnique();

                    b.ToTable("ProfilePhotos");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.PersonalInformation", b =>
                {
                    b.HasOne("PeopleSystem.Database.Models.User", "User")
                        .WithOne("PersonalInformation")
                        .HasForeignKey("PeopleSystem.Database.Models.PersonalInformation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.PlaceOfResidence", b =>
                {
                    b.HasOne("PeopleSystem.Database.Models.PersonalInformation", "PersonalInformation")
                        .WithOne("PlaceOfResidence")
                        .HasForeignKey("PeopleSystem.Database.Models.PlaceOfResidence", "PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.ProfilePhoto", b =>
                {
                    b.HasOne("PeopleSystem.Database.Models.PersonalInformation", "PersonalInformation")
                        .WithOne("ProfilePhoto")
                        .HasForeignKey("PeopleSystem.Database.Models.ProfilePhoto", "PersonalInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.PersonalInformation", b =>
                {
                    b.Navigation("PlaceOfResidence");

                    b.Navigation("ProfilePhoto");
                });

            modelBuilder.Entity("PeopleSystem.Database.Models.User", b =>
                {
                    b.Navigation("PersonalInformation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}