using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflamy.Migrations
{
    public partial class AddMovieSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieID", "Description", "MovieName", "Poster" },
                values: new object[,]
                {
                    { 2, "One Army captain", "Interceptor", "Another Test" },
                    { 3, "The Dreamseller Desccccc", "The Dreamseller", "Another Test" },
                    { 4, "AmericanEastDDDDDDD", "AmericanEast", "Another Test" },
                    { 5, "Frank McKluskyTDs", "Frank McKlusky", "Another Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieID",
                keyValue: 5);
        }
    }
}
