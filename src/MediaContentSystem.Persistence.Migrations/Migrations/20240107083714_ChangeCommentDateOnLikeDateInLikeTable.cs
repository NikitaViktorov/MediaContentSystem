using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaContentSystem.Persistence.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCommentDateOnLikeDateInLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentDate",
                table: "Comments",
                newName: "LikeDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LikeDate",
                table: "Comments",
                newName: "CommentDate");
        }
    }
}
