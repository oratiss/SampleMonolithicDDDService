﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(MelodiveMusicDbContext))]
    partial class DAPHseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.Models.Positions.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomesCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DamageType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ErgonomicStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Persistence.Models.Roles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("SystemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A role for system administrators",
                            IsDeleted = false,
                            SystemDescription = "System.UserManagement.Roles.Admin",
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A role for registered users",
                            IsDeleted = false,
                            SystemDescription = "System.UserManagement.Roles.RegisteredUser",
                            Title = "RegisteredUser"
                        });
                });

            modelBuilder.Entity("Persistence.Models.Positions.Position", b =>
                {
                    b.HasOne("Persistence.Models.Roles.Role", "Role")
                        .WithMany("Positions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SharedValueObject.UserAccounting.PositionActivity", "PositionActivity", b1 =>
                        {
                            b1.Property<int>("PositionId")
                                .HasColumnType("int");

                            b1.Property<bool>("Hearing")
                                .HasColumnType("bit");

                            b1.Property<string>("Other")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("Smelling")
                                .HasColumnType("bit");

                            b1.Property<bool>("Tasting")
                                .HasColumnType("bit");

                            b1.Property<bool>("Thinking")
                                .HasColumnType("bit");

                            b1.Property<bool>("Viewing")
                                .HasColumnType("bit");

                            b1.HasKey("PositionId");

                            b1.ToTable("PositionActivities");

                            b1.WithOwner()
                                .HasForeignKey("PositionId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}