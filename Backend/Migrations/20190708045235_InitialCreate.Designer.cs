﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sandbox.Backend.DataAccess;

namespace Backend.Migrations
{
	[DbContext(typeof(SampleDbContext))]
    [Migration("20190708045235_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Backend.Models.FileData", b =>
                {
                    b.Property<int>("UniqueId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UniqueId");

                    b.ToTable("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
