using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace italk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_ExamId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "Options",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_ExamId",
                table: "Options",
                newName: "IX_Options_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId",
                table: "Options");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Options",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                newName: "IX_Options_ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_ExamId",
                table: "Options",
                column: "ExamId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
