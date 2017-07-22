using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScrewballResume.Migrations
{
    public partial class AddEduModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: false),
                    ConcentrationIn = table.Column<string>(nullable: false),
                    DegreeAttained = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(maxLength: 4, nullable: false),
                    Location = table.Column<string>(nullable: false),
                    OrgName = table.Column<string>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    isCurrent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Educations_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_ApplicantID",
                table: "Educations",
                column: "ApplicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");
        }
    }
}
