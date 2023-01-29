﻿// <auto-generated />
using Database.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230126141635_TreeMigration")]
    partial class TreeMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Entities.FarmArea.FarmAreaDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FarmAreaDbs");
                });

            modelBuilder.Entity("Database.Entities.Sort.TreeSortDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MaxFruitliness")
                        .HasColumnType("float");

                    b.Property<double>("MaxHeight")
                        .HasColumnType("float");

                    b.Property<double>("MaxSquare")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TreeTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TreeTypeId");

                    b.ToTable("TreeSortDbs");
                });

            modelBuilder.Entity("Database.Entities.Tree.TreeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<double>("MaxFruitliness")
                        .HasColumnType("float");

                    b.Property<double>("MaxHeight")
                        .HasColumnType("float");

                    b.Property<double>("MaxSquare")
                        .HasColumnType("float");

                    b.Property<int>("SortId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("TreeDbs");
                });

            modelBuilder.Entity("Database.Entities.Type.TreeTypeDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TreeTypesDb");
                });

            modelBuilder.Entity("Database.Entities.Sort.TreeSortDb", b =>
                {
                    b.HasOne("Database.Entities.Type.TreeTypeDb", "TreeType")
                        .WithMany("TreeSorts")
                        .HasForeignKey("TreeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TreeType");
                });

            modelBuilder.Entity("Database.Entities.Tree.TreeDb", b =>
                {
                    b.HasOne("Database.Entities.FarmArea.FarmAreaDb", "Area")
                        .WithMany("trees")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Database.Entities.FarmArea.FarmAreaDb", b =>
                {
                    b.Navigation("trees");
                });

            modelBuilder.Entity("Database.Entities.Type.TreeTypeDb", b =>
                {
                    b.Navigation("TreeSorts");
                });
#pragma warning restore 612, 618
        }
    }
}
