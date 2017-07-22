﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ScrewballResume.Data;

namespace ScrewballResume.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20170714005227_AddQualModel")]
    partial class AddQualModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScrewballResume.Models.Accomplishment", b =>
                {
                    b.Property<int>("AccomplishmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Accomp")
                        .IsRequired();

                    b.Property<int>("JobID");

                    b.HasKey("AccomplishmentID");

                    b.HasIndex("JobID");

                    b.ToTable("Accomplishments");
                });

            modelBuilder.Entity("ScrewballResume.Models.Applicant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Facebook");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LinkedIn");

                    b.Property<string>("MiddleInit")
                        .HasMaxLength(1);

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("ProfessionalStatement");

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Twitter");

                    b.Property<string>("Website");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("ScrewballResume.Models.Job", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicantID");

                    b.Property<string>("Company")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("FromYear")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("ToYear")
                        .HasMaxLength(4);

                    b.HasKey("JobID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("ScrewballResume.Models.Qualification", b =>
                {
                    b.Property<int>("QualificationID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicantID");

                    b.Property<string>("Skill");

                    b.HasKey("QualificationID");

                    b.HasIndex("ApplicantID");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("ScrewballResume.Models.Accomplishment", b =>
                {
                    b.HasOne("ScrewballResume.Models.Job", "Job")
                        .WithMany("Accomplishments")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ScrewballResume.Models.Job", b =>
                {
                    b.HasOne("ScrewballResume.Models.Applicant", "Applicant")
                        .WithMany("Jobs")
                        .HasForeignKey("ApplicantID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ScrewballResume.Models.Qualification", b =>
                {
                    b.HasOne("ScrewballResume.Models.Applicant", "Applicant")
                        .WithMany("Qualifications")
                        .HasForeignKey("ApplicantID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
