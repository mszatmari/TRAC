using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TRAC.DataAccess.Migrations
{
    public partial class addalltablesdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistStatuss");

            migrationBuilder.CreateTable(
                name: "ChecklistDefinitionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistDefinitionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    CC = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<byte[]>(type: "varbinary(4000)", nullable: true),
                    ReportName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "WBs",
                columns: table => new
                {
                    PRJ_ID_SAP = table.Column<string>(type: "varchar(767)", nullable: false),
                    PRJ_CLI_NAME = table.Column<string>(type: "text", nullable: true),
                    PRJ_Name = table.Column<string>(type: "text", nullable: true),
                    PRJ_Year = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WBs", x => x.PRJ_ID_SAP);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ChecklistDefinitionStatusId = table.Column<int>(type: "int", nullable: true),
                    ChecklistDefinitionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistDefinitions_ChecklistDefinitionStatuses_ChecklistDe~",
                        column: x => x.ChecklistDefinitionId,
                        principalTable: "ChecklistDefinitionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EntityName = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChecklistDefinitionId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    CheckListStatusId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: true),
                    FinancialYear = table.Column<int>(type: "int", nullable: false),
                    RejectedComment = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ValidatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checklists_ChecklistDefinitions_ChecklistDefinitionId",
                        column: x => x.ChecklistDefinitionId,
                        principalTable: "ChecklistDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_ChecklistStatuses_CheckListStatusId",
                        column: x => x.CheckListStatusId,
                        principalTable: "ChecklistStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklists_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checklists_Staffs_ValidatorId",
                        column: x => x.ValidatorId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ChecklistDefinitionId = table.Column<int>(type: "int", nullable: false),
                    SectionOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionDefinitions_ChecklistDefinitions_ChecklistDefinitionId",
                        column: x => x.ChecklistDefinitionId,
                        principalTable: "ChecklistDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    IsAlwaysDisplayed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SectionDefinitionId = table.Column<int>(type: "int", nullable: true),
                    QuestionOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionDefinitions_SectionDefinitions_SectionDefinitionId",
                        column: x => x.SectionDefinitionId,
                        principalTable: "SectionDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(type: "text", nullable: true),
                    QuestionDefinitionId = table.Column<int>(type: "int", nullable: false),
                    InvolveTax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerDefinitions_QuestionDefinitions_QuestionDefinitionId",
                        column: x => x.QuestionDefinitionId,
                        principalTable: "QuestionDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ChecklistId = table.Column<int>(type: "int", nullable: false),
                    AnswerDefinitionId = table.Column<int>(type: "int", nullable: true),
                    QuestionDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AnswerDefinitions_AnswerDefinitionId",
                        column: x => x.AnswerDefinitionId,
                        principalTable: "AnswerDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_QuestionDefinitions_QuestionDefinitionId",
                        column: x => x.QuestionDefinitionId,
                        principalTable: "QuestionDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionDisplayConditions",
                columns: table => new
                {
                    QuestionToDisplayId = table.Column<int>(type: "int", nullable: false),
                    AnswerDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionDisplayConditions", x => new { x.AnswerDefinitionId, x.QuestionToDisplayId });
                    table.ForeignKey(
                        name: "FK_QuestionDisplayConditions_AnswerDefinitions_AnswerDefinition~",
                        column: x => x.AnswerDefinitionId,
                        principalTable: "AnswerDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionDisplayConditions_QuestionDefinitions_QuestionToDisp~",
                        column: x => x.QuestionToDisplayId,
                        principalTable: "QuestionDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChecklistDefinitionStatuses",
                columns: new[] { "Id", "Code", "Label" },
                values: new object[,]
                {
                    { 2, "OPEN", "Open" },
                    { 1, "ClOSED", "Closed" }
                });

            migrationBuilder.InsertData(
                table: "ChecklistDefinitions",
                columns: new[] { "Id", "ChecklistDefinitionId", "ChecklistDefinitionStatusId", "Title" },
                values: new object[] { 1, null, 2, "Checklist 1" });

            migrationBuilder.InsertData(
                table: "ChecklistStatuses",
                columns: new[] { "Id", "Code", "Label" },
                values: new object[,]
                {
                    { 1, "IN_PROGRESS", "In progress" },
                    { 2, "ClOSED", "Closed" },
                    { 3, "PENDING_VALIDATION", "Pending Validation" }
                });

            migrationBuilder.InsertData(
                table: "SectionDefinitions",
                columns: new[] { "Id", "ChecklistDefinitionId", "Name", "SectionOrder" },
                values: new object[] { 1, 1, "Section 1", 1 });

            migrationBuilder.InsertData(
                table: "SectionDefinitions",
                columns: new[] { "Id", "ChecklistDefinitionId", "Name", "SectionOrder" },
                values: new object[] { 2, 1, "Section 2", 2 });

            migrationBuilder.InsertData(
                table: "SectionDefinitions",
                columns: new[] { "Id", "ChecklistDefinitionId", "Name", "SectionOrder" },
                values: new object[] { 3, 1, "Section 3", 3 });

            migrationBuilder.InsertData(
                table: "QuestionDefinitions",
                columns: new[] { "Id", "IsAlwaysDisplayed", "QuestionOrder", "SectionDefinitionId", "Title" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "Question 1" },
                    { 2, true, 2, 1, "Question 2" },
                    { 3, true, 1, 2, "Question 3" },
                    { 4, true, 2, 2, "Question 4" },
                    { 5, true, 1, 3, "Question 5" },
                    { 6, true, 2, 3, "Question 6" }
                });

            migrationBuilder.InsertData(
                table: "AnswerDefinitions",
                columns: new[] { "Id", "InvolveTax", "Label", "QuestionDefinitionId" },
                values: new object[,]
                {
                    { 1, 0, "Yes", 1 },
                    { 2, 0, "No", 1 },
                    { 3, 0, "Yes", 2 },
                    { 4, 0, "No", 2 },
                    { 5, 0, "Yes", 3 },
                    { 6, 0, "No", 3 },
                    { 7, 0, "Yes", 4 },
                    { 8, 0, "No", 4 },
                    { 9, 0, "Yes", 5 },
                    { 10, 0, "No", 5 },
                    { 11, 0, "Yes", 6 },
                    { 12, 0, "No", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerDefinitions_QuestionDefinitionId",
                table: "AnswerDefinitions",
                column: "QuestionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswerDefinitionId",
                table: "Answers",
                column: "AnswerDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ChecklistId",
                table: "Answers",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionDefinitionId",
                table: "Answers",
                column: "QuestionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistDefinitions_ChecklistDefinitionId",
                table: "ChecklistDefinitions",
                column: "ChecklistDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ChecklistDefinitionId",
                table: "Checklists",
                column: "ChecklistDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_CheckListStatusId",
                table: "Checklists",
                column: "CheckListStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ReportId",
                table: "Checklists",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_StaffId",
                table: "Checklists",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklists_ValidatorId",
                table: "Checklists",
                column: "ValidatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDefinitions_SectionDefinitionId",
                table: "QuestionDefinitions",
                column: "SectionDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionDisplayConditions_QuestionToDisplayId",
                table: "QuestionDisplayConditions",
                column: "QuestionToDisplayId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionDefinitions_ChecklistDefinitionId",
                table: "SectionDefinitions",
                column: "ChecklistDefinitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "MailTemplates");

            migrationBuilder.DropTable(
                name: "QuestionDisplayConditions");

            migrationBuilder.DropTable(
                name: "WBs");

            migrationBuilder.DropTable(
                name: "Checklists");

            migrationBuilder.DropTable(
                name: "AnswerDefinitions");

            migrationBuilder.DropTable(
                name: "ChecklistStatuses");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "QuestionDefinitions");

            migrationBuilder.DropTable(
                name: "SectionDefinitions");

            migrationBuilder.DropTable(
                name: "ChecklistDefinitions");

            migrationBuilder.DropTable(
                name: "ChecklistDefinitionStatuses");

            migrationBuilder.CreateTable(
                name: "ChecklistStatuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistStatuss", x => x.Id);
                });
        }
    }
}
