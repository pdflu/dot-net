﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211006041812_messagesEntity")]
    partial class messagesEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Property<long>("ApplicantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Applicant_BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Applicant_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Applicant_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Applicant_Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantID");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.Property<long>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ApplicantID")
                        .HasColumnType("bigint");

                    b.Property<long>("ApplicationStatusID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Application_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Application_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("GradeID")
                        .HasColumnType("bigint");

                    b.Property<int>("SchoolYear")
                        .HasColumnType("int");

                    b.HasKey("ApplicationID");

                    b.HasIndex("ApplicantID");

                    b.HasIndex("ApplicationStatusID");

                    b.HasIndex("GradeID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Property<long>("ApplicationStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplicationStatus_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationStatus_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationtStatus_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicationStatusID");

                    b.ToTable("ApplicationStatuses");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Property<long>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade_Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Grade_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Grade_ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grade_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade_Number")
                        .HasColumnType("int");

                    b.HasKey("GradeID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("DAL.Entities.Message", b =>
                {
                    b.Property<long>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message_Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message_Creation_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message_Modified_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message_Sent_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message_Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DAL.Entities.Student", b =>
                {
                    b.Property<long>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Student_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_Creation_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Profile_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Entities.Application", b =>
                {
                    b.HasOne("DAL.Entities.Applicant", "Applicant")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.ApplicationStatus", "ApplicationStatus")
                        .WithMany("Applications")
                        .HasForeignKey("ApplicationStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Grade", "Grade")
                        .WithMany("Applications")
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("DAL.Entities.Applicant", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.ApplicationStatus", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("DAL.Entities.Grade", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}