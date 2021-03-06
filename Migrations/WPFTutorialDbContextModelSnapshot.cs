// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPFTutorial.DbContexts;

namespace WPFTutorial.Migrations
{
    [DbContext(typeof(WPFTutorialDbContext))]
    partial class WPFTutorialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WPFTutorial.DTOs.ReservationDTO", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
