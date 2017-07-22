using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScrewballResume.Migrations
{
    public partial class AddAffilModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliations",
                columns: table => new
                {
                    AffiliationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AffilOrg = table.Column<string>(nullable: false),
                    ApplicantID = table.Column<int>(nullable: false),
                    From = table.Column<string>(maxLength: 4, nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    To = table.Column<string>(maxLength: 4, nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliations", x => x.AffiliationID);
                    table.ForeignKey(
                        name: "FK_Affiliations_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affiliations_ApplicantID",
                table: "Affiliations",
                column: "ApplicantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affiliations");
        }
    }
}
