using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace italk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Questions_QuestionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_QuestionId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "QuestionsStudent",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsStudent", x => new { x.QuestionsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_QuestionsStudent_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsStudent_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsStudent_StudentsId",
                table: "QuestionsStudent",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionsStudent");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_QuestionId",
                table: "AspNetUsers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Questions_QuestionId",
                table: "AspNetUsers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
