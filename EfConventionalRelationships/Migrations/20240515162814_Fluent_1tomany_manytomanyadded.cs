using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfConventionalRelationships.Migrations
{
    public partial class Fluent_1tomany_manytomanyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "FluentBookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthorMap", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthorMap_FluentAuthors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthorMap_FluentBooks_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookDetails_Book_Id",
                table: "FluentBookDetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_Book_Id",
                table: "FluentBookDetails",
                column: "Book_Id",
                principalTable: "FluentBooks",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id",
                principalTable: "FluentPublishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_Book_Id",
                table: "FluentBookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropTable(
                name: "Fluent_BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookDetails_Book_Id",
                table: "FluentBookDetails");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "FluentBookDetails");
        }
    }
}
