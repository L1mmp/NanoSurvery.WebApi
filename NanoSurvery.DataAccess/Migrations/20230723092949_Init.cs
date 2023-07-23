using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NanoSurvery.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentQuestionNumber = table.Column<int>(type: "integer", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerInterviews",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    InterviewId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerInterviews", x => new { x.AnswerId, x.InterviewId });
                    table.ForeignKey(
                        name: "FK_AnswerInterviews_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerInterviews_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreatedOn", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("40c1d1c2-6184-4a70-a92e-4c0a3dabcb9e"), new DateTime(2023, 7, 23, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8509), "Description for Survey 2", "Survey 2" },
                    { new Guid("e39480d3-7fd9-4d77-ba5d-75cebbb4d591"), new DateTime(2023, 7, 23, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8506), "Description for Survey 1", "Survey 1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "RefreshToken", "TokenCreated", "TokenExpires", "Username" },
                values: new object[,]
                {
                    { new Guid("eb147c56-5ff1-45d8-adca-39c4d0871e31"), "password1", null, new DateTime(2023, 7, 23, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8618), new DateTime(2023, 7, 30, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8618), "user1" },
                    { new Guid("f7483e73-155d-42f2-8d1c-6feb0592c5d5"), "password2", null, new DateTime(2023, 7, 23, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8624), new DateTime(2023, 7, 30, 9, 29, 49, 93, DateTimeKind.Utc).AddTicks(8624), "user2" }
                });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "Id", "CurrentQuestionNumber", "IsFinished", "SurveyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d25387d-262d-43ca-86ec-a7098ea77d2a"), 0, false, new Guid("e39480d3-7fd9-4d77-ba5d-75cebbb4d591"), new Guid("f7483e73-155d-42f2-8d1c-6feb0592c5d5") },
                    { new Guid("543312b1-f6c5-43c0-9255-ee129a4bb3d4"), 0, false, new Guid("40c1d1c2-6184-4a70-a92e-4c0a3dabcb9e"), new Guid("eb147c56-5ff1-45d8-adca-39c4d0871e31") },
                    { new Guid("7ec8fc0c-f782-4349-97ec-1a4d55fdb8c2"), 0, false, new Guid("40c1d1c2-6184-4a70-a92e-4c0a3dabcb9e"), new Guid("f7483e73-155d-42f2-8d1c-6feb0592c5d5") },
                    { new Guid("a89b3485-c256-45d4-baf2-9c9edd369e12"), 0, false, new Guid("e39480d3-7fd9-4d77-ba5d-75cebbb4d591"), new Guid("eb147c56-5ff1-45d8-adca-39c4d0871e31") }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Number", "SurveyId", "Title" },
                values: new object[,]
                {
                    { new Guid("4e0e07b0-80d0-4c17-902e-267cb514dec8"), 1, new Guid("40c1d1c2-6184-4a70-a92e-4c0a3dabcb9e"), "Question 2" },
                    { new Guid("4f16b568-939a-46ae-b008-e974c619bafa"), 1, new Guid("e39480d3-7fd9-4d77-ba5d-75cebbb4d591"), "Question 2" },
                    { new Guid("fa41fab7-25be-4b2b-a97a-546b0989798e"), 0, new Guid("40c1d1c2-6184-4a70-a92e-4c0a3dabcb9e"), "Question 1" },
                    { new Guid("fec4dd00-ba69-4e4b-90b2-aa6832c55ca4"), 0, new Guid("e39480d3-7fd9-4d77-ba5d-75cebbb4d591"), "Question 1" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "QuestionId", "Text" },
                values: new object[,]
                {
                    { new Guid("00005347-5f69-4914-b0ff-a3d7932c9989"), new Guid("fa41fab7-25be-4b2b-a97a-546b0989798e"), "Answer 1" },
                    { new Guid("628b5479-d062-4a7f-9380-ad791d9d18ed"), new Guid("fec4dd00-ba69-4e4b-90b2-aa6832c55ca4"), "Answer 1" },
                    { new Guid("70200c8e-d7ab-4f4e-9641-91715415100b"), new Guid("fec4dd00-ba69-4e4b-90b2-aa6832c55ca4"), "Answer 2" },
                    { new Guid("9a8f40ac-35e8-4d4b-90b0-fbaa5babf261"), new Guid("4f16b568-939a-46ae-b008-e974c619bafa"), "Answer 1" },
                    { new Guid("9dd62573-7feb-4388-aa87-ce1b3721d026"), new Guid("fa41fab7-25be-4b2b-a97a-546b0989798e"), "Answer 2" },
                    { new Guid("e4280494-dc08-40d0-a81d-be55905a52c5"), new Guid("4f16b568-939a-46ae-b008-e974c619bafa"), "Answer 2" },
                    { new Guid("f818655b-7053-40d9-893f-220a894b89ac"), new Guid("fec4dd00-ba69-4e4b-90b2-aa6832c55ca4"), "Answer 3" }
                });

            migrationBuilder.InsertData(
                table: "AnswerInterviews",
                columns: new[] { "AnswerId", "InterviewId" },
                values: new object[,]
                {
                    { new Guid("00005347-5f69-4914-b0ff-a3d7932c9989"), new Guid("543312b1-f6c5-43c0-9255-ee129a4bb3d4") },
                    { new Guid("628b5479-d062-4a7f-9380-ad791d9d18ed"), new Guid("a89b3485-c256-45d4-baf2-9c9edd369e12") },
                    { new Guid("9a8f40ac-35e8-4d4b-90b0-fbaa5babf261"), new Guid("a89b3485-c256-45d4-baf2-9c9edd369e12") },
                    { new Guid("9dd62573-7feb-4388-aa87-ce1b3721d026"), new Guid("7ec8fc0c-f782-4349-97ec-1a4d55fdb8c2") },
                    { new Guid("e4280494-dc08-40d0-a81d-be55905a52c5"), new Guid("0d25387d-262d-43ca-86ec-a7098ea77d2a") },
                    { new Guid("f818655b-7053-40d9-893f-220a894b89ac"), new Guid("0d25387d-262d-43ca-86ec-a7098ea77d2a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerInterviews_InterviewId",
                table: "AnswerInterviews",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_SurveyId",
                table: "Interviews",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_UserId",
                table: "Interviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

			migrationBuilder.Sql(@"
                    CREATE OR REPLACE VIEW ""AnswerInterviewResults"" AS
                    SELECT
                        ""q"".""Id"" AS ""QuestionId"",
                        ""q"".""Title"" AS ""QuestionTitle"",
                        ""a"".""Id"" AS ""AnswerId"",
                        ""a"".""Text"" AS ""AnswerText"",
                        COUNT(""ai"".""AnswerId"") AS ""AnswerCount""
                    FROM
                        ""AnswerInterviews"" ""ai""
                    RIGHT JOIN ""Answers"" ""a"" 
                        ON ""a"".""Id"" = ""ai"".""AnswerId""
                    JOIN ""Questions"" ""q"" 
                        ON ""q"".""Id"" = ""a"".""QuestionId""
                    GROUP BY
                        ""q"".""Id"",
                        ""q"".""Title"",
                        ""a"".""Id"",
                        ""a"".""Text"";
            ");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP VIEW IF EXISTS ""AnswerInterviewResults""");

			migrationBuilder.DropTable(
                name: "AnswerInterviews");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
