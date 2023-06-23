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
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Languages_LanguageId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseReservation_AspNetUsers_StudentId",
                table: "CourseReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseReservation_Course_CourseId",
                table: "CourseReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseReservation",
                table: "CourseReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "CourseReservation",
                newName: "CourseResrvation");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseReservation_CourseId",
                table: "CourseResrvation",
                newName: "IX_CourseResrvation_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_LanguageId",
                table: "Courses",
                newName: "IX_Courses_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_InstructorId",
                table: "Courses",
                newName: "IX_Courses_InstructorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseResrvation",
                table: "CourseResrvation",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResrvation_AspNetUsers_StudentId",
                table: "CourseResrvation",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseResrvation_Courses_CourseId",
                table: "CourseResrvation",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Languages_LanguageId",
                table: "Courses",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResrvation_AspNetUsers_StudentId",
                table: "CourseResrvation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseResrvation_Courses_CourseId",
                table: "CourseResrvation");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Languages_LanguageId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseResrvation",
                table: "CourseResrvation");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "CourseResrvation",
                newName: "CourseReservation");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_LanguageId",
                table: "Course",
                newName: "IX_Course_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_InstructorId",
                table: "Course",
                newName: "IX_Course_InstructorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseResrvation_CourseId",
                table: "CourseReservation",
                newName: "IX_CourseReservation_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseReservation",
                table: "CourseReservation",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_InstructorId",
                table: "Course",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Languages_LanguageId",
                table: "Course",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseReservation_AspNetUsers_StudentId",
                table: "CourseReservation",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseReservation_Course_CourseId",
                table: "CourseReservation",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
