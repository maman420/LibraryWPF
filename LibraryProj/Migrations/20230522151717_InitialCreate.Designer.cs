﻿// <auto-generated />
using LibraryProj.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryProj.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230522151717_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryProj.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("LibraryProj.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "science fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "money"
                        },
                        new
                        {
                            Id = 3,
                            Name = "health"
                        });
                });

            modelBuilder.Entity("LibraryProj.Book", b =>
                {
                    b.HasBaseType("LibraryProj.Item");

                    b.HasDiscriminator().HasValue("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author 1",
                            CategoryId = 1,
                            Description = "Description 1",
                            Name = "Book 1",
                            Price = 20,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author 2",
                            CategoryId = 2,
                            Description = "Description 2",
                            Name = "Book 2",
                            Price = 15,
                            Stock = 5
                        });
                });

            modelBuilder.Entity("LibraryProj.Journal", b =>
                {
                    b.HasBaseType("LibraryProj.Item");

                    b.Property<int>("Issn")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Journal");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Author = "Publisher 1",
                            CategoryId = 1,
                            Description = "Description 3",
                            Name = "Journal 1",
                            Price = 25,
                            Stock = 8,
                            Issn = 0
                        },
                        new
                        {
                            Id = 4,
                            Author = "Publisher 2",
                            CategoryId = 3,
                            Description = "Description 4",
                            Name = "Journal 2",
                            Price = 30,
                            Stock = 12,
                            Issn = 0
                        });
                });

            modelBuilder.Entity("LibraryProj.Item", b =>
                {
                    b.HasOne("LibraryProj.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LibraryProj.Models.Category", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
