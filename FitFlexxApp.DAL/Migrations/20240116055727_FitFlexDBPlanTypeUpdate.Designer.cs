﻿// <auto-generated />
using FitFlexApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitFlexxApp.DAL.Migrations
{
    [DbContext(typeof(FitFlexAppContext))]
    [Migration("20240116055727_FitFlexDBPlanTypeUpdate")]
    partial class FitFlexDBPlanTypeUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FitFlexApp.DAL.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlanTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserAccessPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanTypeId");

                    b.HasIndex("UserAccessPlanId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.PlanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlanType");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.UserAccessPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFee")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccessPlans");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.Plan", b =>
                {
                    b.HasOne("FitFlexApp.DAL.Entities.PlanType", "PlanType")
                        .WithMany()
                        .HasForeignKey("PlanTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitFlexApp.DAL.Entities.UserAccessPlan", "UserAccessPlan")
                        .WithMany("Plans")
                        .HasForeignKey("UserAccessPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanType");

                    b.Navigation("UserAccessPlan");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.UserAccessPlan", b =>
                {
                    b.HasOne("FitFlexApp.DAL.Entities.User", "User")
                        .WithMany("UserAccessPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.User", b =>
                {
                    b.Navigation("UserAccessPlans");
                });

            modelBuilder.Entity("FitFlexApp.DAL.Entities.UserAccessPlan", b =>
                {
                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
