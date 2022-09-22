﻿// <auto-generated />
using System;
using GymManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManagement.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220922202546_mig2")]
    partial class mig2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymManagement.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Height");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<int>("MemberNumber")
                        .HasColumnType("int")
                        .HasColumnName("MemberNumber");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("UpdatedAt");

                    b.Property<double>("Weight")
                        .HasColumnType("float")
                        .HasColumnName("Weight");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Members", (string)null);
                });

            modelBuilder.Entity("GymManagement.Domain.Entities.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<int>("TrainerNumber")
                        .HasColumnType("int")
                        .HasColumnName("TrainerNumber");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Trainers", (string)null);
                });

            modelBuilder.Entity("GymManagement.Domain.Entities.Member", b =>
                {
                    b.HasOne("GymManagement.Domain.Entities.Trainer", "Trainer")
                        .WithMany("Members")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("GymManagement.Domain.Entities.Trainer", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}