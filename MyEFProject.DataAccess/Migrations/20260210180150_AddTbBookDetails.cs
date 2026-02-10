using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTbBookDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Books");
        }
    }
}
