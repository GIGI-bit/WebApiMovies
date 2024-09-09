using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiMovies.Migrations
{
    /// <inheritdoc />
    public partial class update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ResponseId",
                table: "Movies",
                column: "ResponseId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_ResponseId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "Movies");
        }
    }
}
