using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScrewballResume.Migrations
{
    public partial class AddQualModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    LinkedIn = table.Column<string>(nullable: true),
                    MiddleInit = table.Column<string>(maxLength: 1, nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    ProfessionalStatement = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FromYear = table.Column<string>(maxLength: 4, nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ToYear = table.Column<string>(maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: false),
                    Skill = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_Qualifications_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accomplishments",
                columns: table => new
                {
                    AccomplishmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomp = table.Column<string>(nullable: false),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accomplishments", x => x.AccomplishmentID);
                    table.ForeignKey(
                        name: "FK_Accomplishments_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accomplishments_JobID",
                table: "Accomplishments",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ApplicantID",
                table: "Jobs",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_ApplicantID",
                table: "Qualifications",
                column: "ApplicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accomplishments");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
