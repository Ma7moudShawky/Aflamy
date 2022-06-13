using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflamy.Migrations
{
    public partial class ManyToManySolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Movies_MovieID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MovieID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CustomIdentityUserMovie",
                columns: table => new
                {
                    UserFavoritesMovieID = table.Column<int>(type: "int", nullable: false),
                    UsersWhoFavoriteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomIdentityUserMovie", x => new { x.UserFavoritesMovieID, x.UsersWhoFavoriteId });
                    table.ForeignKey(
                        name: "FK_CustomIdentityUserMovie_AspNetUsers_UsersWhoFavoriteId",
                        column: x => x.UsersWhoFavoriteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomIdentityUserMovie_Movies_UserFavoritesMovieID",
                        column: x => x.UserFavoritesMovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "53eb9848-483a-42a4-8006-8dcebc6795bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "015ae1bc-36af-44b1-ad4e-9460c79f4466");

            migrationBuilder.CreateIndex(
                name: "IX_CustomIdentityUserMovie_UsersWhoFavoriteId",
                table: "CustomIdentityUserMovie",
                column: "UsersWhoFavoriteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomIdentityUserMovie");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ffa04ad1-6291-477d-8cad-b88692b81e87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3b303566-4f93-460a-9728-73e8adcf74bf");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MovieID",
                table: "AspNetUsers",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Movies_MovieID",
                table: "AspNetUsers",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID");
        }
    }
}
