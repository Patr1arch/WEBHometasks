using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication1.Migrations
{
    public partial class Genre_Filmadnothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallsId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_HallsId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "HallsId",
                table: "Seats");

            migrationBuilder.CreateTable(
                name: "Genre_Films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre_Films", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "Genre_Films");

            migrationBuilder.DropIndex(
                name: "IX_Seats_HallId",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "HallsId",
                table: "Seats",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_HallsId",
                table: "Seats",
                column: "HallsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallsId",
                table: "Seats",
                column: "HallsId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
