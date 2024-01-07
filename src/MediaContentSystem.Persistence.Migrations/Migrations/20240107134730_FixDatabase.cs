using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaContentSystem.Persistence.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Likes",
                newName: "LikeDate");

            migrationBuilder.RenameColumn(
                name: "LikeDate",
                table: "Comments",
                newName: "CommentDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LikeDate",
                table: "Likes",
                newName: "CommentDate");

            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "LikeDate");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Users",
                type: "nvarchar(11)",
                nullable: true);
        }
    }
}
