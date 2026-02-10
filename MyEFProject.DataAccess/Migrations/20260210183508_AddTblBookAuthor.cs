using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTblBookAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Book_Id",
                table: "BookAuthors",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_Publisher_Id",
                table: "Books",
                column: "Publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_Publisher_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_Books_Publisher_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Books");
        }
    }
}
