﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.TodoList", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ListId");

                    b.ToTable("TodoList");
                });

            modelBuilder.Entity("Entity.TodoListTask", b =>
                {
                    b.Property<int>("ListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListItemId"));

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.HasKey("ListItemId");

                    b.HasIndex("ListId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Entity.TodoListTask", b =>
                {
                    b.HasOne("Entity.TodoList", "TodoList")
                        .WithMany("Tasks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoList");
                });

            modelBuilder.Entity("Entity.TodoList", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}