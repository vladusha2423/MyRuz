﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyRUZ.Models;

namespace MyRUZ.Migrations
{
    [DbContext(typeof(MyRUZDbContext))]
    [Migration("20190205114335_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyRUZ.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auditorium");

                    b.Property<string>("BeginLesson");

                    b.Property<string>("Building");

                    b.Property<string>("Comment");

                    b.Property<string>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("EndLesson");

                    b.Property<string>("Lecturer");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.Property<string>("Stream");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
