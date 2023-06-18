using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace italk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateImgName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imgname",
                table: "AspNetUsers",
                newName: "ImgName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "AspNetUsers",
                newName: "Imgname");
        }
    }
}
