using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEFProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addfluenttbls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_Author",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Author", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_BookDetails",
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
                    table.PrimaryKey("PK_Fluent_BookDetails", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Books",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false),
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Books", x => x.Book_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publishers", x => x.Publisher_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_Author");

            migrationBuilder.DropTable(
                name: "Fluent_BookDetails");

            migrationBuilder.DropTable(
                name: "Fluent_Books");

            migrationBuilder.DropTable(
                name: "Fluent_Publishers");
        }
    }
}
