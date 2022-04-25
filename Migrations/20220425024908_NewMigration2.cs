using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class NewMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Favorites_PostID",
                table: "Favorites",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Posts_PostID",
                table: "Favorites",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Posts_PostID",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_PostID",
                table: "Favorites");
        }
    }
}
