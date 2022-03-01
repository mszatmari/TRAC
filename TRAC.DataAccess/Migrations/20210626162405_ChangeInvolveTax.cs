using Microsoft.EntityFrameworkCore.Migrations;

namespace TRAC.DataAccess.Migrations
{
    public partial class ChangeInvolveTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistDefinitions_ChecklistDefinitionStatuses_ChecklistDe~",
                table: "ChecklistDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistDefinitions_ChecklistDefinitionId",
                table: "ChecklistDefinitions");

            migrationBuilder.DropColumn(
                name: "ChecklistDefinitionId",
                table: "ChecklistDefinitions");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistDefinitions_ChecklistDefinitionStatusId",
                table: "ChecklistDefinitions",
                column: "ChecklistDefinitionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistDefinitions_ChecklistDefinitionStatuses_ChecklistDe~",
                table: "ChecklistDefinitions",
                column: "ChecklistDefinitionStatusId",
                principalTable: "ChecklistDefinitionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistDefinitions_ChecklistDefinitionStatuses_ChecklistDe~",
                table: "ChecklistDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistDefinitions_ChecklistDefinitionStatusId",
                table: "ChecklistDefinitions");

            migrationBuilder.AddColumn<int>(
                name: "ChecklistDefinitionId",
                table: "ChecklistDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistDefinitions_ChecklistDefinitionId",
                table: "ChecklistDefinitions",
                column: "ChecklistDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistDefinitions_ChecklistDefinitionStatuses_ChecklistDe~",
                table: "ChecklistDefinitions",
                column: "ChecklistDefinitionId",
                principalTable: "ChecklistDefinitionStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
