using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScrewballResume.Migrations
{
    public partial class AddCertModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantID = table.Column<int>(nullable: false),
                    CertAuthority = table.Column<string>(nullable: true),
                    CertName = table.Column<string>(nullable: false),
                    CertURL = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    IsEternal = table.Column<bool>(nullable: false),
                    LicenseNum = table.Column<string>(nullable: true),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertificationID);
                    table.ForeignKey(
                        name: "FK_Certifications_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ApplicantID",
                table: "Certifications",
                column: "ApplicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");
        }
    }
}
