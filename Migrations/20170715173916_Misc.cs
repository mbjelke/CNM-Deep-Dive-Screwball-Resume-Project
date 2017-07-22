using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScrewballResume.Migrations
{
    public partial class Misc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reference_Applicants_ApplicantID",
                table: "Reference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reference",
                table: "Reference");

            migrationBuilder.RenameTable(
                name: "Reference",
                newName: "References");

            migrationBuilder.RenameIndex(
                name: "IX_Reference_ApplicantID",
                table: "References",
                newName: "IX_References_ApplicantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_References",
                table: "References",
                column: "ReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_References_Applicants_ApplicantID",
                table: "References",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_References_Applicants_ApplicantID",
                table: "References");

            migrationBuilder.DropPrimaryKey(
                name: "PK_References",
                table: "References");

            migrationBuilder.RenameTable(
                name: "References",
                newName: "Reference");

            migrationBuilder.RenameIndex(
                name: "IX_References_ApplicantID",
                table: "Reference",
                newName: "IX_Reference_ApplicantID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reference",
                table: "Reference",
                column: "ReferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reference_Applicants_ApplicantID",
                table: "Reference",
                column: "ApplicantID",
                principalTable: "Applicants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
