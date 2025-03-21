using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Migrations
{
    /// <inheritdoc />
    public partial class AddParentIdToCommentaires : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Commentaires",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_ParentId",
                table: "Commentaires",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Commentaires_ParentId",
                table: "Commentaires",
                column: "ParentId",
                principalTable: "Commentaires",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Commentaires_ParentId",
                table: "Commentaires");

            migrationBuilder.DropIndex(
                name: "IX_Commentaires_ParentId",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Commentaires");
        }
    }
}
