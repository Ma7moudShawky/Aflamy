using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflamy.Migrations
{
    public partial class AddMovieSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "Description", "MovieName", "Poster" },
                values: new object[] { 1, "Will's soon-to-be ex-wife mysteriously vanishes ", "Last Seen Alive", "JustTest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 1);
        }
    }
}
